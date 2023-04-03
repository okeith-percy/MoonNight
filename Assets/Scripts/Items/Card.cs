using UnityEngine;
using UnityEngine.UI;
using TMPro;
[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public Sprite cardSprite;
    [TextArea(1, 3)]
    public string cardDescription;
    [SerializeField]
    Item.MemoryType type;

}

[System.Serializable]
public class CardPrefab
{
    public TMP_Text CardName;
    public Image CardImage;
    public TMP_Text CardDescription;


    public CardPrefab(GameObject cardPrefab)
    {

        GameObject cardBody = cardPrefab.GetComponentInChildren<Image>().gameObject;
        CardImage = cardBody.transform.GetChild(0).gameObject.GetComponent<Image>();
        CardDescription = cardBody.transform.GetChild(1).gameObject.GetComponentInChildren<TMP_Text>();
        CardName = cardBody.transform.GetChild(2).gameObject.GetComponentInChildren<TMP_Text>();

    }

    public void SetCardUI(Card card)
    {

        CardName.SetText(card.cardName);
        CardDescription.SetText(card.cardDescription);
        CardImage.sprite = card.cardSprite;
    }


}

[System.Serializable]
public class CardGallery
{
    public CardPrefab[] cards;

    public CardGallery(GameObject[] cardSlots, int size)
    {
        cards = new CardPrefab[size];

        for (int i = 0; i < size; i++)
        {
            cards[i] = new CardPrefab(cardSlots[i]);
        }
    }



}


