using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager am;

    public List<AudioClip> playlist;
    private int currentTrack = 0;
    public AudioSource audioSource;

    private void Awake()
    {
        if (am == null)
        {
            am = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = playlist[currentTrack];
        audioSource.Play();
    }
    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            currentTrack++;
            if (currentTrack >= playlist.Count)
            {
                currentTrack = 0;
            }
            audioSource.clip = playlist[currentTrack];
            audioSource.Play();
        }
    }
    public void PlayClip(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

    }
}
