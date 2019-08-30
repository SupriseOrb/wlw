using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    //For changing the mouse cursor!
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool hasMessage = true;
    public bool isInteractable;
    public bool wait = false;

    //OWO
    public PlayerController player;
    public DialogueManager dialogueManager;

     void Start()
    {
        player = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        isInteractable = false;
    }

    public void ChangeInteractableFalse()
    {
        isInteractable = false;
    }

    public void ChangeInteractableTrue()
    {
        isInteractable = true;
    }

    public void ChangeWaitFalse(){
        wait = false;
    }

    public void ChangeWaitTrue(){
        wait = true;
    }

    //For Cursors
    void OnMouseEnter()
    {
        //if(!player.inConversation && hasMessage)
        if(hasMessage)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        
    }

    void OnMouseDown()
    {
        if(!player.inConversation && hasMessage && isInteractable && !wait){
            player.ChangeInConversationTrue(); //A little better

            //Cursor.SetCursor(null, Vector2.zero, cursorMode);
            TriggerDialogue();

        }
        
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue, this);
    }

}
