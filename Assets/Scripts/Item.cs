
using UnityEngine;

public class Item : MonoBehaviour
{
    public int memId;
    public AudioMemory audo;
    public DIalogueMemory dia;
    public MediaMemory medi;
    public PictureMemory pic;
    public bool isInteracted = false;
    public bool interactable;
    public bool didInteract = false;
    private void Start()
    {


    }

    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            interactable = true;
            isInteractable(interactable);


        }
    }

    private void OnTriggerExit2D(Collider2D player)
    {
        if (player.CompareTag("Player"))
        {
            interactable = false;
            isInteractable(interactable);
            if (dia != null) dia.dialogBox.SetActive(false);
            if (pic != null) { pic.pictureCanvas.SetActive(false); pic.background.SetActive(false); }
        }
    }

    private void isInteractable(bool _interactable)
    {

        if (_interactable)
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.8f);

        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
    }



}






