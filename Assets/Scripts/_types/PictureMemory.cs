using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureMemory : MonoBehaviour
{
    public GameObject pictureCanvas;
    public GameObject background;
    public GameObject mainPicture;
    public Sprite imageSource;
    private Player playerRef;
    private void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<Player>();
        if (playerRef == null) Debug.LogError("Memory doesnt have reference to Player!");
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
        playerRef.canMove = true;
    }

}
