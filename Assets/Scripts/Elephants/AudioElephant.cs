using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Annie, the Audio Elephant is all about the jams. Her favorite jams are all over the eras but are timeless.
// Annie's current jams are All by Myself by Celine Dion and Greatness by Quavo 
public class AudioElephant : MonoBehaviour
{

    public static AudioElephant Annie;
    public List<AudioClip> playlist;
    private int currentTrack = 0;
    public AudioSource audioSource;

    private void Awake()
    {
        if (Annie != null) return;
        Annie = this;
        DontDestroyOnLoad(Annie.gameObject);

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
    //MementoSana is Annie's special function, where she can play the beautiful sound of an Audio Memory
    public void MementoSana(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();

    }
}
