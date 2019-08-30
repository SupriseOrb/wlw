using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    private Queue<string> sentences;
    private Queue<string> names;

    public Animator animator;


    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        //nameText.text = dialogue.name;
        //Debug.Log("Starting conversation with " + dialogue.name);

        names.Clear();
        sentences.Clear();
        foreach(DialogueTuples dT in dialogue.tuple)
        {
            sentences.Enqueue(dT.sentences);
            names.Enqueue(dT.names);
        }
        DisplayNextSentences();
        /*foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }
        foreach (string n in dialogue.names)
        {
            names.Enqueue(n);
        }
        DisplayNextSentences();*/
    }

    public void DisplayNextSentences()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        nameText.text = names.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
        Debug.Log(sentence);
    }

    IEnumerator TypeSentence (string sentence)
    {
        player.canProceed = false;
        dialogueText.text = "";
        foreach( char letter in sentence.ToCharArray())
        { 
            dialogueText.text += letter;
            yield return null;
            if(Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
            {
                dialogueText.text = sentence;
                player.canProceed = true;
                yield break;
            }
            
        }
        player.canProceed = true;
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        player.inConversation = false;
        player.canProceed = false;
        Debug.Log("End of Conversation");
    }

}
