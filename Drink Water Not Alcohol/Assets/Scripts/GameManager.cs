using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public PlayerController player;

    //For Courage Bar
    public float barDisplay; //current progress
    public Vector2 pos = new Vector2(20,40);
    public Vector2 size = new Vector2(60,20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void Start()
    {
        dialogueManager = this.GetComponent<DialogueManager>();
        player = FindObjectOfType<PlayerController>();
    }

    // void FixedUpdate()
    // {
            
    // }
    void Update()
    {
        continueDialogue();
    }

    void continueDialogue()
    {   
        Debug.Log("continueDialogue()");
        //if(player.canProceed && player.inConversation && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        if(player.canProceed && player.inConversation && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.DisplayNextSentences();
        }
    }

    
}
