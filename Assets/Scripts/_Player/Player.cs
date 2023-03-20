using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Item interactedItem;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private LayerMask itemLayer;
    private Vector2 movement;
    private Vector2 faceDirection;
    [SerializeField] private Animator anima;
    [SerializeField] TMP_Text interactText;
    [SerializeField] TMP_Text collectText;
    private bool canInteract;
    public bool canMove;
    private bool itemInRange;
    private void Awake()
    {
        if (instance != null) { Debug.LogWarning("More then one instance of the Player has been found!"); return; }

        instance = this;

        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody not attached");

        anima = GetComponent<Animator>();
        if (anima == null) Debug.LogError("Anima not attached");
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
    }
    // Update is called once per frame
    void Update()
    {

        MoveInput();
        Interact();
        if (Input.GetKeyDown(KeyCode.R)) PlayCard();

    }
    //FixedUpdate is called once per frame at the fixed rate
    private void FixedUpdate()
    {
        Move();
    }


    // MoveInput is when the player presses A&D or W&S Keys and the player animation is set in that direction
    void MoveInput()
    {
        canMove = false;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y)) movement.y = 0;
        else movement.x = 0;

        if (movement.x > 0 || movement.x < 0)
        {
            canMove = true;
            faceDirection = new Vector2(movement.x, 0);
        }
        if (movement.y > 0 || movement.y < 0)
        {
            canMove = true;
            faceDirection = new Vector2(0, movement.y);
        }

        anima.SetFloat("moveX", movement.x);
        anima.SetFloat("moveY", movement.y);
        anima.SetBool("canMove", canMove);
        anima.SetFloat("lastMoveX", faceDirection.x);
        anima.SetFloat("lastMoveY", faceDirection.y);

    }

    //Move is a function that moves the rigidbody of the player based off the MoveInput
    private void Move()
    {
        if (canMove) rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }


    //InteractInput is when the player presses E and an item is in range, the player can interact
    void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit2D hitItem = Physics2D.Raycast(transform.position, faceDirection, .5f, itemLayer);
            if (hitItem.collider)
            {
                interactedItem = hitItem.collider.GetComponent<Item>();
                if (interactedItem?.interactable ?? false)
                {

                    if (interactedItem.didInteract && !interactedItem.collected) Collect(interactedItem.card);
                    else Play(interactedItem);

                }
            }
            else
            {
                Debug.DrawLine(transform.position, (Vector2)transform.position + faceDirection * 3f, Color.green, 2f);
                Debug.Log("No Item");
            }
        }

    }

    //Collect the associated Card on an item.
    void Collect(Card card)
    {
        var collectedCard = card;
        Collection.collection.Add(collectedCard);
        interactedItem.collected = true;
        interactText.text = "Interact";
    }

    void Play(Item item)
    {
        var playItem = item;
        MemoryElephant.MemMaw.MementoAmoris(interactedItem);
        item.didInteract = true;
        interactText.text = "Collect";
    }

    // PlayCard will play the first card in the collection (at the moment)
    void PlayCard()
    {
        if (Collection.collection.isShowing)
        {
            // Collection.collection.Hide();
            Debug.Log("I AM SHOWING");
        }
        Collection.collection.ViewCollection();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            var item = other.GetComponent<Item>();
            interactText.gameObject.SetActive(true);
            interactText.rectTransform.anchoredPosition = new Vector2(this.transform.position.x + 2, this.transform.position.y);
            interactText.text = (item.didInteract && !item.collected) ? "Collect" : "Interact";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            interactText?.gameObject.SetActive(false);
        }
    }



}
