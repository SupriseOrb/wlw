using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueTuples{
    //public string names;
    public NPC peep;
    //public AudioClip sfx;
    [TextArea(3,10)]
    public string sentences;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueTuples[] tuple;
    public int deltaCourage;
    
}


