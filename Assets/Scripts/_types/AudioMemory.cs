using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioMemory : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;
    private Player playerRef;
    private void Start()
    {
        playerRef = GameObject.Find("Player").GetComponent<Player>();
        if (playerRef == null) Debug.LogError("Memory doesnt have reference to Player!");
    }
    public void Play()
    {
        audioSource.playOnAwake = false;
        audioSource.clip = audioClip;
        audioSource.Play();


    }
    public void Update()
    {
        if (!audioSource.isPlaying)
        {
            playerRef.canMove = true;
        }
    }
}
