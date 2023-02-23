using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextMemory : MonoBehaviour
{

    public GameObject dialogBox;
    public Text dialogText;
    public string dialogue;
    public bool dialogActive;

    [SerializeField] int _id = 2;


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
        Player.instance.canMove = false;
    }
    public int GetID()
    {
        return _id;
    }
}
