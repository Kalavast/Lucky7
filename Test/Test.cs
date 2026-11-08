using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private HandView handView;
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)){
            CardDisplay cardDisplay = CardDisplayCreator.Instance.CreateCardDisplay(transform.position, Quaternion.identity);
            StartCoroutine(handView.AddCard(cardDisplay).GetEnumerator());
        }
    }
}
