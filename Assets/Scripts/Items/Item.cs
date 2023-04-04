
using UnityEngine;
using UnityEngine.UI;
using TMPro;
[RequireComponent(typeof(BoxCollider2D))]
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
    public bool canCollect;
    public bool collected;
    public bool interactable;
    public bool didInteract;

    public Card card;


    private void Start()
    {
        canCollect = false;
        collected = false;
        didInteract = false;
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
            if (this.memoryType == MemoryType.Dialogue)
            {
                DialogueElephant.DeeDee.Stop();
            }
            // if (Player.instance.interactedItem != null) { Player.instance.interactedItem = null; }
        }
    }




}






