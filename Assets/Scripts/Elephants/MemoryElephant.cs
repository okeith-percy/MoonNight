using UnityEngine;

// MemMaw, the Memory Elephant. She was there for it all and will continue to do so.
//The Matriarch and The first of the herd, MeeMaw ressonance with memories is incredible, making her able to channel 
//energy into the other Elephants allowing them to show off their own loves and talents.
public class MemoryElephant : MonoBehaviour
{
    public static MemoryElephant MemMaw;

    private void Awake()
    {
        if (MemMaw != null) return;
        MemMaw = this;
        DontDestroyOnLoad(MemMaw.gameObject);
    }

    //Memento Amoris represents MemMaw special function, giving functionality to her herd that gives them the ability to resonate with the memory in the item
    public void MementoAmoris(Item item)
    {
        switch (item.memoryType)
        {
            case Item.MemoryType.Audio:
                AudioMemory audioMemory = item.GetComponent<AudioMemory>();
                audioMemory.Resonate();
                break;
            case Item.MemoryType.Dialogue:
                DialogueMemory dialogueMemory = item.GetComponent<DialogueMemory>();
                dialogueMemory.Resonate();
                break;
            case Item.MemoryType.Picture:
                PictureMemory pictureMemory = item.GetComponent<PictureMemory>();
                pictureMemory.Resonate();
                break;
            case Item.MemoryType.Video:
                VideoMemory videoMemory = item.GetComponent<VideoMemory>();
                videoMemory.Resonate();
                break;
            default:
                break;
        }

    }



}
