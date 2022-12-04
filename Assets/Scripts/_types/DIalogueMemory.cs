using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DIalogueMemory : MonoBehaviour
{
    private Player playerRef;
    public GameObject dialogBox;
    public Text dialogText;
    public string dialogue;
    public bool dialogActive;

    private void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<Player>();
        if (playerRef == null) Debug.LogError("Memory doesnt have reference to Player!");
    }



    public void Play()
    {
        if (dialogBox.activeInHierarchy)
        {
            dialogBox.SetActive(false);
        }
        else
        {
            dialogBox.SetActive(true);
            dialogText.text = dialogue;
        }
        playerRef.canMove = true;
    }
}
