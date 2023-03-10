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

    [SerializeField] GameObject cardPrefab;



    void Awake()
    {
        if (collection != null) { return; }
        collection = this;
        DontDestroyOnLoad(collection.gameObject);
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
        isShowing = true;
        Debug.Log(card.cardName);
    }

    public void Hide()
    {
        cardPrefab.SetActive(false);
        isShowing = false;
    }

}
