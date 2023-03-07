
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class Item : MonoBehaviour
{
    public enum MemoryType
    {
        Audio,
        Dialogue,
        Picture,
        Video
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

            if (didInteract && card != null)
            {
                Debug.Log("I can still be collected -" + card.cardName);
            }
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
            if (this.memoryType == MemoryType.Dialogue)
            {
                DialogueElephant.DeeDee.Stop();
            }
            // if (Player.instance.interactedItem != null) { Player.instance.interactedItem = null; }
        }
    }




}






