using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public static Collection collection;
    public List<Card> cards = new List<Card>();
    public bool isShowing;
    public CardPrefab card;
    [SerializeField]
    CardGallery cardGallery;

    void Awake()
    {
        if (collection != null) { return; }
        collection = this;
    }

    public void Add(Card card)
    {
        cards.Add(card);

        //Assign the card to its UI counterpart

    }
    void DisplayCards()
    {

    }

    void SetCardUI(Card newCard)
    {
        card.card_name.text = newCard.cardName;
        card.card_image.sprite = newCard.cardSprite;
        card.card_description.text = newCard.cardDesc;
    }
    void SetCardGalleryUI(Card newCard)
    {

    }
    public void Show(Card newCard)
    {
        SetCardUI(newCard);
        card.Display.SetActive(true);

        isShowing = true;
        Debug.Log(newCard.cardName);
    }

    public void Hide()
    {
        card.Display.SetActive(false);
        isShowing = false;
    }


    public void ViewCollection()
    {
        // GameObject CardBG = CardGallery.GetComponentInChildren<GameObject>();
        for (int i = 0; i < cards.Count; i++)
        {
            cardGallery.cards[i].card_name.text = cards[i].cardName;
            cardGallery.cards[i].card_image.sprite = cards[i].cardSprite;
            cardGallery.cards[i].card_description.text = cards[i].cardDesc;


            //View by card type
            switch (cards[i].GetMemoryType())
            {
                case Item.MemoryType.Audio:
                    Debug.Log("HeA");
                    break;

                case Item.MemoryType.Dialogue:
                    Debug.Log("HeD");
                    break;

                case Item.MemoryType.Picture:
                    Debug.Log("HeP");
                    break;

                case Item.MemoryType.Video:
                    Debug.Log("HeV");
                    break;
            }
        }
        cardGallery.Display.SetActive(true);

    }
}
