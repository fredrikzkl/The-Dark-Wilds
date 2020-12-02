using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animatator;
    private Queue<string> sentences;
    

    void Start()
    {
        sentences = new Queue<string>();
    }

    
    public void StartDialogue(Dialogue dialogue)
    {
        Debug.Log("Starting conversation with: " + dialogue.Name);
        animatator.SetBool("isOpen", true);
        nameText.text = dialogue.Name;

        sentences.Clear();

        foreach(string s in dialogue.sentences)
        {
            sentences.Enqueue(s);
        }

        DisplayNextSentance();
    }

    public void DisplayNextSentance()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        
        dialogueText.text = sentences.Dequeue();
        
    }

    public void EndDialogue()
    {
        animatator.SetBool("isOpen", false);
        Debug.Log("End of conversation");
    }
}
