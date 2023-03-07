using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureElephant : MonoBehaviour
{
    public GameObject pictureCanvas;
    public GameObject backgroundImage;
    public GameObject mainImage;
    public static PictureElephant Penne;

    private void Awake()
    {
        if (Penne != null) return;
        Penne = this;
        DontDestroyOnLoad(Penne.gameObject);
    }

    // memento picturam
    public void MementoPicturam(UnityEngine.Sprite image)
    {

        if (pictureCanvas.activeInHierarchy)
        {
            pictureCanvas.SetActive(false);
            backgroundImage.SetActive(false);
        }
        else
        {
            pictureCanvas.SetActive(true);
            backgroundImage.SetActive(true);
            mainImage.GetComponent<UnityEngine.UI.Image>().sprite = image;

        }
        StartCoroutine(GracefulExit(pictureCanvas));
    }
    IEnumerator GracefulExit(GameObject pc)
    {
        yield return new WaitForSeconds(2);
        pc.SetActive(false);
        Player.instance.canMove = true;

    }
}
