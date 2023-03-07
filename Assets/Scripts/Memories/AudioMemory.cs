using UnityEngine;

public class AudioMemory : MonoBehaviour
{

    public AudioClip audioClip;
    [SerializeField] int _id = 0;

    public void Resonate()
    {
        AudioElephant.Annie.MementoSana(audioClip);
    }
    public int GetID()
    {
        return _id;
    }

}
