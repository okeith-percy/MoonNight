using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ConstantMusic : MonoBehaviour
{

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    private void Update()
    {

        if (SceneManager.GetActiveScene().name == "Scene2")
        {
            transform.gameObject.GetComponent<AudioSource>().Stop();
        }
        if (SceneManager.GetActiveScene().name == "Scene1")
        {
            if (GameObject.Find("PianoMusic").GetComponent<AudioSource>().isPlaying == true)
            {
                transform.gameObject.GetComponent<AudioSource>().mute = true;
            }
            else
            {
                transform.gameObject.GetComponent<AudioSource>().mute = false;
            }
        }
    }

}
