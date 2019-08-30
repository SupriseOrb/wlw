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
    }
    
    private void movement()
    {
        if(!inConversation){
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb.AddForce (movement*speed, ForceMode2D.Impulse);
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
        if(other.gameObject.CompareTag("Interactable")){
            other.gameObject.GetComponent<DialogueTrigger>().ChangeInteractableTrue();
        }
    }

     void OnTriggerExit2D (Collider2D other)
     {
         if(other.gameObject.CompareTag("Interactable")){
            other.gameObject.GetComponent<DialogueTrigger>().ChangeInteractableFalse();
        }
     }

    public void ChangeInConversationTrue(){
        inConversation = true;
     }
     public void ChangeInConversationFalse(){
        inConversation = false;
     }
     
     public void ChangeCanProceedTrue(){
         canProceed = true;
     }

     public void ChangeCanProceedFalse(){
         canProceed = false;
     }
 }
