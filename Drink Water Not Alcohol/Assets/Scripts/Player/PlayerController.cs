using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    public DialogueManager dialogueManager;

    public bool inConversation = false;
    public bool canProceed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dialogueManager = FindObjectOfType<DialogueManager>();
    }
    void FixedUpdate()
    {
        movement();
        spriteFixer();
        continueDialogue();
    }

    void continueDialogue()
    {
        if(canProceed && inConversation && (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1)))
        {
            dialogueManager.DisplayNextSentences();
        }
    }
    private void movement()
    {
        // if(Input.GetKeyUp(KeyCode.W) && Input.GetKeyUp(KeyCode.A) &&
        //     Input.GetKeyUp(KeyCode.S) && Input.GetKeyUp(KeyCode.D))
        //     {
                
        //     }
        if(!inConversation){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.AddForce (movement*speed, ForceMode2D.Impulse);
            //transform.Translate(moveHorizontal, moveVertical, 0);
        }
        
    }

    private void spriteFixer()
    {
        transform.position = new Vector3(transform.position.x, 
                                            transform.position.y, 
                                            transform.position.y * 0.01f);
    }

    void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.gameObject.name);
        other.gameObject.GetComponent<DialogueTrigger>().ChangeInteractableTrue();
    }

     void OnTriggerExit2D (Collider2D other)
     {
         Debug.Log("I'm not touching the something anymore");
         other.gameObject.GetComponent<DialogueTrigger>().ChangeInteractableFalse();
     }
 }
