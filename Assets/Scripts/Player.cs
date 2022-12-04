using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] Item interactedItem;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    private Vector2 movement;
    private Vector2 moveDirection;
    //Animations
    [SerializeField] private Anima anima;

    private bool canInteract;
    public bool canMove;
    private bool itemInRange;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        if (rb == null) Debug.LogError("Rigidbody not attached");

        anima = GetComponent<Anima>();
        if (anima == null) Debug.LogError("Anima not attached");
    }
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;

    }
    void Update()
    {

        MoveInput();
        if (Input.GetKeyDown(KeyCode.E) && itemInRange)
        {
            canInteract = true;
        }

    }
    private void FixedUpdate()
    {

        Move();

        Interact();


    }
    // Update is called once per frame

    void MoveInput()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(movement.x) > Mathf.Abs(movement.y))
        {
            movement.y = 0;
        }
        else
        {
            movement.x = 0;
        }
        if (movement != Vector2.zero)
        {
            if (moveDirection.x > 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.WALK_RIGHT);
            }
            else if (moveDirection.x < 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.WALK_LEFT);
            }
            else if (moveDirection.y > 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.WALK_UP);
            }
            else if (moveDirection.y < 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.WALK_DOWN);
            }
            //MoveDirection is lastMovement
            //Movement is current movement
            moveDirection = movement;

        }
        else
        {
            if (moveDirection.x > 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.IDLE_RIGHT);
            }
            else if (moveDirection.x < 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.IDLE_LEFT);
            }
            else if (moveDirection.y > 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.IDLE_UP);
            }
            else if (moveDirection.y < 0)
            {
                anima.ChangeAnimationState(Anima.PlayerAnimations.IDLE_DOWN);
            }
        }

    }


    private void Move()
    {
        if (canMove)
        {
            rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        }
    }
    void SetAim(Item newItem, bool isInteractable, int type)
    {
        interactedItem = newItem;
        if (isInteractable)
        {
            canMove = false;
            switch (type)
            {
                case 1:
                    interactedItem.audo.Play();
                    break;
                case 2:

                    interactedItem.dia.Play();
                    break;
                case 3:
                    interactedItem.medi.Play();
                    break;
                case 4:
                    interactedItem.pic.Play();
                    break;
                default:
                    break;
            }

        }
        Debug.Log("Do I ever get called?");
        canInteract = false;
        interactedItem = null;


    }
    private void Interact()
    {

        if (canInteract)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, movement, 3f, 1 << LayerMask.NameToLayer("Item"));


            if (hit.collider != null)
            {

                Item item = hit.collider.GetComponent<Item>();
                if (item != null)
                {

                    SetAim(item, item.interactable, item.memId);

                    Debug.Log("Interacted with " + item.name);
                }

            }
            else
            {
                Debug.Log("No Item");
                SetAim(null, false, 0);

            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = false;
        }
    }


}
