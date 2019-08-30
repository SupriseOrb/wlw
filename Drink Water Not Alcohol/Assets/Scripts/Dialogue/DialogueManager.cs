using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
//using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    //For changing dialogue box text!
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public UnityEngine.UI.Image profile;
    private Queue<string> sentences;
    private Queue<string> names;
    private Queue<NPC> npcs;
    private DialogueTrigger currentDialogueTrigger;

    //For dialogue box animations!
    public Animator animator;

    //Why do I have a reference to the player??? sighs
    public PlayerController player;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        sentences = new Queue<string>();
        names = new Queue<string>();
        npcs = new Queue<NPC>();
    }

    public void StartDialogue(Dialogue dialogue, DialogueTrigger dialogueTrigger)
    {
        animator.SetBool("isOpen", true);
        currentDialogueTrigger = dialogueTrigger;

        names.Clear();
        sentences.Clear();
        foreach(DialogueTuples dT in dialogue.tuple)
        {
            sentences.Enqueue(dT.sentences);
            names.Enqueue(dT.names);
            npcs.Enqueue(dT.peep);
        }
        DisplayNextSentences();
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
        profile.sprite = npcs.Dequeue().artwork;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        player.ChangeCanProceedFalse(); //A little better
        dialogueText.text = "";
        foreach( char letter in sentence.ToCharArray())
        { 
            dialogueText.text += letter;
            yield return null;
            //if(Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            if(Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
            {
                dialogueText.text = sentence;
                player.ChangeCanProceedTrue(); //A little better
                yield break;
            }
            
        }
        player.ChangeCanProceedTrue(); //A little better
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        player.ChangeInConversationFalse(); //A little better
        player.ChangeCanProceedFalse(); //A little better
        StartTimer(); //so that you don't get stuck in infinite conversation loop
    }

    public void StartTimer(){
        StartCoroutine(TimeoutDialogueTrigger());
    }
    IEnumerator TimeoutDialogueTrigger(){
        currentDialogueTrigger.ChangeWaitTrue();
        yield return new WaitForSeconds(0.25f);
        currentDialogueTrigger.ChangeWaitFalse();
    }

}
