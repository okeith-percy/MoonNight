using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMemory : Memory
{

    public AudioClip audioClip;
    [SerializeField] int _id = 0;


    public void Play()
    {
        AudioManager.am.PlayClip(audioClip);
    }
    public int GetID()
    {
        return _id;
    }

}
