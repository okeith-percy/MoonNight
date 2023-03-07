using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMemory : MonoBehaviour
{


    public UnityEngine.Video.VideoClip videoClip;
    int _id = 3;


    public void Resonate()
    {
        VideoElephant.Vinny.MementoVideo(videoClip);
    }

    public int GetID()
    {
        return _id;
    }

}
