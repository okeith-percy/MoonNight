using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public static Collection instance;
    public List<Card> cards = new List<Card>();



    void Awake()
    {
        if (instance != null) { Debug.LogWarning("More then one instance of Collection has been found!"); return; }
        instance = this;
    }

    public void Add(Card card)
    {
        cards.Add(card);

    }
}
