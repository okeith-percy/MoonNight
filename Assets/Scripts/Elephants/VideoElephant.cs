using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoElephant : MonoBehaviour
{

    public static VideoElephant Vinny;
    [SerializeField] GameObject videoCanvas;
    [SerializeField] UnityEngine.Video.VideoPlayer videoPlayer;
    public UnityEngine.Video.VideoClip videoClip;
    int _id = 3;

    private void Awake()
    {
        if (Vinny != null) return;
        Vinny = this;
        DontDestroyOnLoad(Vinny.gameObject);

    }
    // MementoVideo is Vinny's special function once he resonate with a video memory, he plays the clip for all to see. 
    public void MementoVideo(UnityEngine.Video.VideoClip videoClip)
    {
        videoCanvas.SetActive(true);
        videoPlayer.clip = videoClip;
        videoPlayer.loopPointReached += EndReached;
        videoPlayer.Prepare();
        videoPlayer.Play();

    }
    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        StartCoroutine(GracefulExit(vp));
    }
    IEnumerator GracefulExit(UnityEngine.Video.VideoPlayer vp)
    {
        yield return new WaitForSeconds(2);
        videoCanvas.SetActive(false);
        vp.clip = null;
        Player.instance.canMove = true;

    }

    public int GetID()
    {
        return _id;
    }


}
