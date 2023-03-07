using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PictureMemory : MonoBehaviour
{

    public Sprite imageSource;
    [SerializeField] int _id = 1;

    public void Resonate()
    {
        PictureElephant.Penne.MementoPicturam(imageSource);
    }

    public int GetID()
    {
        return _id;
    }

}
