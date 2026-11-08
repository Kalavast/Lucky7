using UnityEngine;

namespace SinuousProductions {
    [CreateAssetMenu(fileName = "New Card", menuName = "Card")]
    public class Card : ScriptableObject {
        public string cardName;
        public CardType cardType;
        public int value;
        public enum CardType {
            Basic,
            Special,
            Curse
        }
        
    }
}
public class Card
{
    
}
