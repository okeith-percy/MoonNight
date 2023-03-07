using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Meet DeeDee, the Dialogue Elephant!
//Meaning she never shuts up but we love DeeDee cause DeeDee is sweet  :)
public class DialogueElephant : MonoBehaviour
{

    public static DialogueElephant DeeDee;
    [SerializeField] GameObject dialogueBox;
    [SerializeField] Text dialogueText;
    [SerializeField] Queue<string> sentences = new Queue<string>();

    private void Awake()
    {
        if (DeeDee != null) return;
        DeeDee = this;
        DontDestroyOnLoad(DeeDee.gameObject);

    }
    //MementoSermonis is DeeDee's function to personify the memory by reading the Dialogue memory eloquently.
    public void MementoSermonis(Dialogue dialogue)
    {
        sentences.Clear();
        dialogueBox.SetActive(true);
        StartCoroutine(TypeSentence(dialogue.sentences[0]));
        foreach (string sentence in dialogue.sentences[1..^0]) sentences.Enqueue(sentence);
        // StartCoroutine(AutoNextSentence());
    }
    public void Stop()
    {
        dialogueBox.SetActive(false);
    }

    void NextSentence()
    {
        if (sentences.Count == 0)
        {
            DialogueElephant.DeeDee.Stop();
            return;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator AutoNextSentence()
    {
        yield return new WaitForSeconds(2);
        if (sentences.Count == 0)
        {
            yield return new WaitForSeconds(2);
            DialogueElephant.DeeDee.Stop();
            yield break;
        }
        string sentence = sentences.Dequeue();
        StartCoroutine(TypeSentence(sentence));
        StartCoroutine(AutoNextSentence());
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
        yield break;
    }

}
