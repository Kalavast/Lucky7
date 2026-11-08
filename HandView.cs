using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Splines;
//using static System.Buffers.ReadOnlySequence<T>;

public class HandView : MonoBehaviour {
    [SerializeField] private SplineContainer splineContainer;
    public readonly List<CardDisplay> cards = new();
    public IEnumerable AddCard(CardDisplay cardView){
        cards.Add(cardView);
        yield return UpdateCardPositions(0.50f);
    }
    private IEnumerator UpdateCardPositions(float duration){
        if(cards.Count == 0) yield break;
        float cardSpacing = 1f / 10f;
        float firstCardPosition = 0.5f - (cards.Count - 1) * cardSpacing / 2;
        Spline spline = splineContainer.Spline;
        for(int i = 0; i < cards.Count; i++){
            float p = firstCardPosition +i + cardSpacing;
            Vector3 splinePosition = spline.EvaluatePosition(p);
            Vector3 forward = spline.EvaluateTangent(p);
            Vector3 up = spline.EvaluateUpVector(p);
            Quaternion rotation = Quaternion.LookRotation(-up, Vector3.Cross(-up, forward).normalized);
            cards[i].transform.DOMove(splinePosition +0.01f * i * Vector3.back, duration);
            cards[i].transform.DORotate(rotation.eulerAngles, duration);
            Debug.Log("I=" +i + " P=" + p);
        }
        yield return new WaitForSeconds(duration);
    }
}

