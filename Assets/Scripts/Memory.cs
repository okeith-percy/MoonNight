using UnityEngine;

public class Memory : MonoBehaviour
{
    public static Memory instance;

    private AudioMemory audioMemory;
    private TextMemory textMemory;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayMemory(Item item)
    {
        switch (item.memoryType)
        {
            case Item.MemoryType.Audio:
                AudioMemory audioMemory = item.GetComponent<AudioMemory>();
                audioMemory.Play();
                break;
            case Item.MemoryType.Text:
                TextMemory textMemory = item.GetComponent<TextMemory>();
                textMemory.Play();
                break;
            default:
                break;
        }
    }



}
