using UnityEngine;


public class DialogueMemory : MonoBehaviour
{
    public Dialogue dialogue;

    [SerializeField] int _id = 2;

    public void Resonate()
    {
        DialogueElephant.DeeDee.MementoSermonis(dialogue);
    }

    public int GetID()
    {
        return _id;
    }
}
