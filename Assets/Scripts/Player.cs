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
        if (instance != null) { Debug.LogWarning("More then one instance of Player has been found!"); return; }

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
        Collect();

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
            RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDirection, .5f, itemLayer);
            if (hit.collider != null)
            {

                Debug.DrawLine(transform.position, hit.point, Color.red, 10f);
                interactedItem = hit.collider.GetComponent<Item>();
                if (interactedItem != null && interactedItem?.interactable == true)
                {
                    canMove = false;
                    Memory.instance.PlayMemory(interactedItem);
                    interactedItem.didInteract = true;
                    Debug.Log("Interacted with " + interactedItem?.name);
                }

            }
            else
            {
                Debug.DrawLine(transform.position, (Vector2)transform.position + faceDirection * 3f, Color.green, 2f);
                Debug.Log("No Item");
            }
        }

    }
    // This works but I think I don't want to repeat them and have Collect be a different way
    private void Collect()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {

            RaycastHit2D hit = Physics2D.Raycast(transform.position, faceDirection, .5f, itemLayer);
            if (hit.collider != null)
            {

                Debug.DrawLine(transform.position, hit.point, Color.red, 10f);
                interactedItem = hit.collider.GetComponent<Item>();
                if (interactedItem != null && interactedItem?.interactable == true)
                {
                    canMove = false;
                    Collection.instance.Add(interactedItem?.card);
                    Debug.Log("Collected " + interactedItem?.name);
                }

            }
            else
            {
                Debug.DrawLine(transform.position, (Vector2)transform.position + faceDirection * 3f, Color.green, 2f);
                Debug.Log("No Item");
            }
        }


    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            interactText.gameObject.SetActive(true);
            interactText.rectTransform.anchoredPosition = new Vector2(this.transform.position.x + 2, this.transform.position.y);
            var item = other.GetComponent<Item>();
            if (item.didInteract && !item.collected)
            {
                item.canCollect = true;
                interactText.text = "Collect";
                // collectText.rectTransform.anchoredPosition = new Vector2(this.transform.position.x + 2, this.transform.position.y - 0.5f);

            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            interactText?.gameObject.SetActive(false);
            collectText?.gameObject.SetActive(false);
        }
    }



}
