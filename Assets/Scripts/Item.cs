
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public enum MemoryType
    {
        Audio,
        Text
    }
    public MemoryType memoryType;
    public bool canCollect = false;
    public bool collected = false;
    public bool interactable;
    public bool didInteract = false;

    public GameObject cardPrefab;
    public Card card;


    private void Start()
    {


    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            interactable = true;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);

            // why use a ui text element that is annoying, and why not use a sprite instead
            // interactImage.gameObject.SetActive(true);
            if (didInteract && card != null)
            {
                cardPrefab.GetComponentInChildren<TMP_Text>().text = card.cardName;
                cardPrefab.GetComponentInChildren<Image>().sprite = card.cardSprite;
                cardPrefab.SetActive(true);
                Debug.Log(card.cardName);


            }
            // cardPrefab.SetActive(true);
            // cardPrefab.GetComponent<CardDisplay>().card = card;
            // cardPrefab.GetComponentInChildren<TMP_Text>().text = card.cardName;
            // cardPrefab.GetComponentInChildren<Image>().sprite = card.cardSprite;
            // if (canCollect && card != null) Collection.instance.Add(card); card = null;
            // Debug.Log(card.cardName);
        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            interactable = false;
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
            cardPrefab.SetActive(false);
            // interactImage.gameObject.SetActive(false);
            if (this.gameObject.GetComponent<TextMemory>() != null) this.gameObject.GetComponent<TextMemory>().dialogBox.SetActive(false);
            // if (pic != null) { pic.pictureCanvas.SetActive(false); pic.background.SetActive(false); }
            if (Player.instance.interactedItem != null) { Player.instance.interactedItem = null; }
        }
    }




}






