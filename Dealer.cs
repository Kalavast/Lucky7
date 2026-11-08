using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
public class Dealer : MonoBehaviour {
    public DeckManager deckManager;
    [SerializeField] public GameObject _cardPrefab;
    public Transform HandTransform;
   // public List<Card>deck = new List<Card>();
    //private Stack<Card> Stack = new Stack<Card>();
    //public bool[] avaliableCardSlots;
    public List<GameObject> cardsInHand = new List<GameObject>();
    public Text deckSizeText;
    public float fanSpread = 7.5f;
    public float cardSpacing = -100f;
    public float verticalSpacing = 10f;
    // private GameObject _spawnedCard;


    public void DrawCard(Card cardData) {
        //if(deck.Count >= 1) {
            GameObject DrawnCard = Instantiate(_cardPrefab, HandTransform.position, Quaternion.identity);
            cardsInHand.Add(DrawnCard);
            

            //set the CardData of the drawn card
            DrawnCard.GetComponent<CardDisplay>().cardData = cardData;

            UpdateCardHandVisuals();
            //Card DrawnCard = Stack.Pop();
            
            // for (int i = 0; i < avaliableCardSlots.Length; i++) {
            //     if (avaliableCardSlots[i] == true) {
            //         // DrawnCard.gameObject.SetActive(true);
            //         // DrawnCard.transform.position = cardSlots[i].position;
            //         avaliableCardSlots[i] = false;
            //         return;
            //     }
            // }
        //}
        // Logic for drawing a card from the deck can be added here
    }
    private void UpdateCardHandVisuals() {
        int cardCount = cardsInHand.Count;

        if (cardCount == 1) {
            cardsInHand[0].transform.localRotation = Quaternion.Euler(0f,0f,0f);
            cardsInHand[0].transform.localPosition = new Vector3(0f,0f,0f);
            return;
        }

        for (int i = 0; i < cardCount; i++) {
            float rotationAngle = (fanSpread * (i - cardCount - 1) / 2f); // Adjust the angle as needed
            cardsInHand[i].transform.localRotation = Quaternion.Euler(0f, 0f, rotationAngle);

            float horizontalOffset = (cardSpacing * (i - (cardCount - 1) / 2f));
            float normalizedPosition = (2f * i / (cardCount - 1)); // normallize card position between -1 and 1
            float verticalOffset = verticalSpacing * (1 - normalizedPosition * normalizedPosition);
            cardsInHand[i].transform.localPosition = new Vector3(horizontalOffset, verticalOffset, 0f);
        }
    }

    void Start() {
        deckManager.DrawCard(this);
        // Example of instantiating a card prefab
        //HandManager handManager = FindAnyObjectByType<HandManager>();
        // if (handManager != null)
        // DrawCard(handManager.hand[0]);
        // _spawnedCard = Instantiate(_cardPrefab);
        // GameObject card = Instantiate(_cardPrefab, transform.position, Quaternion.identity);
        // Additional logic for dealing cards can be added here
    }
    void Update() {
        //deckSizeText.text = deck.Count.ToString();
        // Logic for updating the dealer's state can be added here
    }
    
}
