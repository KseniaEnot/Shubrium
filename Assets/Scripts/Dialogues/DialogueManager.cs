using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Dialogue dialogue;

    public GameObject dialogueBox;

    private Queue<string> sentences;

    public GameObject nextDialogue;

    private void Start()
    {
        sentences = new Queue<string>();
    }

    public void Update()
    {
        if (dialogueBox.activeSelf == true && Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextSentence();
        }
    }

    public void StartDialogue()
    {
        dialogueBox.SetActive(true);

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
    public void EndDialogue()
    {
        dialogueBox.SetActive(false);
        if (nextDialogue  != null)
        {
            nextDialogue.SetActive(true);
        }    
        gameObject.SetActive(false);
    }
}
