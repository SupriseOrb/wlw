using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    public bool hasMessage = true;
    public bool isInteractable;

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
    void OnMouseEnter()
    {
        if(!player.inConversation && hasMessage)
        {
            Debug.Log("Mouse is over GameObject");
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }
    }

    void OnMouseExit()
    {
        Debug.Log("Mouse is no longer on GameObject");
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        
    }

    void OnMouseDown()
    {
        if(!player.inConversation && hasMessage && isInteractable){
            Debug.Log("I've been clicked!");
            player.inConversation = true;

            Cursor.SetCursor(null, Vector2.zero, cursorMode);
            TriggerDialogue();

        }
        
    }
    public void TriggerDialogue()
    {
        dialogueManager.StartDialogue(dialogue);
    }

}
