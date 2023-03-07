using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Collection : MonoBehaviour
{
    public static Collection collection;
    public List<Card> cards = new List<Card>();

    [SerializeField] GameObject cardPrefab;



    void Awake()
    {
        if (collection != null) { Debug.LogWarning("More then one instance of Collection has been found!"); return; }
        collection = this;

    }

    public void Add(Card card)
    {
        cards.Add(card);
    }

    public void Show(Card card)
    {
        cardPrefab.GetComponentInChildren<TMP_Text>().text = card.cardName;
        cardPrefab.GetComponentInChildren<Image>().sprite = card.cardSprite;
        cardPrefab.SetActive(true);
        Debug.Log(card.cardName);
    }
    public void Play()
    {

    }
}
