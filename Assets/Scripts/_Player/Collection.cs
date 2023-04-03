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
    public GameObject cardPrefab;
    public GameObject[] cardSlots;
    [SerializeField]
    private CardPrefab defaultCard;
    public Card tempCard;
    [SerializeField]
    CardGallery cardGallery;
    [SerializeField]
    GameObject cardGalleryUI;
    [SerializeField]
    TMP_Text cardGalleryPageUI;
    private int page = 0;

    void Awake()
    {
        if (collection != null) { return; }
        collection = this;

    }
    private void Start()
    {
        defaultCard = new CardPrefab(cardPrefab);
        cardGallery = new CardGallery(cardSlots, 30);

    }

    private void Update()
    {
        UpdatePage();

    }
    private void UpdatePage()
    {

        if (Input.GetKeyDown(KeyCode.T))
        {
            if (page >= 3) page = 0;
            page++;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (page <= 0)
            {
                page = 4;
            }
            page--;
        }
        cardGalleryPageUI.SetText("{0}/{1}", page + 1, Mathf.FloorToInt((30 - 1) / 8));
    }
    public void Add(Card card)
    {
        cards.Add(card);
        tempCard = card;

        //Assign the card to its UI counterpart

    }
    void DisplayCards()
    {

    }


    public void Show()
    {
        // defaultCard.UpdateCard(tempCard);
        // defaultCard.CardDisplay.SetActive(true);
        // Debug.LogFormat("I AM {0}", defaultCard.CardDisplay.activeInHierarchy);

        isShowing = true;
    }

    public void Hide()
    {
        Debug.Log("HIde");
        cardGalleryUI.SetActive(false); isShowing = false;
    }


    public void ViewCollection()
    {
        UpdatePage();
        for (int i = 0; i < cards.Count; i++)
        {
            cardGallery.cards[i].SetCardUI(cards[i]);
            cardSlots[i].SetActive(true);
        }
        isShowing = true;
        cardGalleryUI.SetActive(true);

    }
}
