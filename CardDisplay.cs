using UnityEngine;
using UnityEngine.UI;
public class CardDisplay : MonoBehaviour {
    public Card cardData;
    [SerializeField] public SpriteRenderer image ;
    [SerializeField] public GameObject Wrapper;
    //public Image[] typeImages;

    void Start(){
        UpdateCardDisplay();
    }
    public void UpdateCardDisplay(){
        
    }
}