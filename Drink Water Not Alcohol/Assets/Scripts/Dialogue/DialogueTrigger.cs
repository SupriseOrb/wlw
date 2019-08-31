using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    public GameManager gameManager;

     void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        dialogueManager = FindObjectOfType<DialogueManager>();
        gameManager = FindObjectOfType<GameManager>();
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
    void OnMouseOver()
    {
        if(hasMessage)
        {
            Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        }else{
            Cursor.SetCursor(null, Vector2.zero, cursorMode);
        }
    }

    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
        
    }

    void OnMouseDown()
    {
        if(!player.inConversation && hasMessage && isInteractable && !wait){
            TriggerDialogue();
        }
        
    }
    public void TriggerDialogue()
    {
        player.ChangeInConversationTrue(); //A little better
        dialogueManager.StartDialogue(dialogue, this);
    }

    public void ChangeHasMessageFalse(){
        if(this.CompareTag("Flora")){
            hasMessage = true;
            if(gameManager.endGoalTriggered){
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
            }
        }else{
            hasMessage = false;
        }
    }

}
