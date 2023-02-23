using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureMemory : MonoBehaviour
{
    public GameObject pictureCanvas;
    public GameObject background;
    public GameObject mainPicture;
    public Sprite imageSource;
    [SerializeField] int _id = 1;
    private void Start()
    {

    }
    public void Play()
    {
        if (pictureCanvas.activeInHierarchy)
        {
            pictureCanvas.SetActive(false);
            background.SetActive(false);
        }
        else
        {
            pictureCanvas.SetActive(true);
            background.SetActive(true);
            mainPicture.GetComponent<UnityEngine.UI.Image>().sprite = imageSource;

        }
        Player.instance.canMove = true;
    }
    public int GetID()
    {
        return _id;
    }

}
