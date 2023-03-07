using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


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
