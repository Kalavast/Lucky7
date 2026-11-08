using UnityEngine;
using System.Collections.Generic;
using SinuousProductions;
using static TMPro.TMP_DefaultControls;
//using Deck;
public class DeckManager : MonoBehaviour {
    [SerializeField] public List<Card> deck = new List<Card>();
    private int currentIndex = 0;
    public void DrawCard(Dealer dealer){
        if (deck.Count == 0){
            return;
        }

        Card nextCard = deck[currentIndex];
        dealer.DrawCard(nextCard);
        currentIndex = (currentIndex + 1) % deck.Count;
    }


    void Start()
    {


        //deck.AddRange(deckInstance.deck);
        
        currentIndex = (currentIndex + 1);
        //Card[] cards = Resources.LoadAll<Card>("Cards");
        
        Dealer dealer = FindAnyObjectByType<Dealer>();//may want to split Dealer into also a HandManager class
        for(int i = 0; i < 6; i++){
            DrawCard(dealer);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
