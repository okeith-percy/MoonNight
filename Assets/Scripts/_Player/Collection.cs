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

    void Awake()
    {
        if (collection != null) { return; }
        collection = this;
    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void Show(Card newCard)
    {
        card.card_name.text = newCard.cardName;
        card.card_image.sprite = newCard.cardSprite;
        card.card_description.text = newCard.cardDesc;
        card.CardDisplay.SetActive(true);

        isShowing = true;
        Debug.Log(newCard.cardName);
    }

    public void Hide()
    {
        card.CardDisplay.SetActive(false);
        isShowing = false;
    }



}
