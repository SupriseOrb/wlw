using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public DialogueManager dialogueManager;
    public PlayerController player;
    public DialogueTrigger intro;
    public DialogueTrigger flora;
    public Dialogue floraConclusion;
    public DialogueTrigger readyForFlora;
    public bool endGoalTriggered = false;

    //For Courage Bar
    public int intialCourage = 0;
    public int currentCourage; //current progress
    public UnityEngine.UI.Slider courageSlider;
    

    void Awake(){
        dialogueManager = this.GetComponent<DialogueManager>();
        player = FindObjectOfType<PlayerController>();
        currentCourage = intialCourage;
    }
    void Start()
    {
        
        intro.TriggerDialogue();
    }

    void Update()
    {
        continueDialogue();
    }
    void continueDialogue()
    {   
        if(player.canProceed && player.inConversation && Input.anyKeyDown && !Input.GetKeyDown(KeyCode.Escape))
        {
            dialogueManager.DisplayNextSentences();
        }
    }
    void EndGoalMet(){
        flora.dialogue = floraConclusion;
        endGoalTriggered = true;
        readyForFlora.TriggerDialogue();
        
    }

    public void gainCourage(int deltaCourage){
        if(!endGoalTriggered){
            currentCourage += deltaCourage;
            courageSlider.value = currentCourage;
            if(currentCourage >= 100){
                EndGoalMet();
            }
        }
    }
    
}
