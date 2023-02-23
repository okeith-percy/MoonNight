using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoMemory : MonoBehaviour
{
    // Start is called before the first frame update

    public UnityEngine.Video.VideoClip videoClip;
    int _id = 3;



    public void Play()
    {
        GameObject camera = GameObject.Find("Main Camera");

        var videoPlayer = camera.GetComponent<UnityEngine.Video.VideoPlayer>();
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
        vp.clip = null;
        Player.instance.canMove = true;

    }

    public int GetID()
    {
        return _id;
    }

}
