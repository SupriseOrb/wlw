using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueTuples{
    public string names;

    [TextArea(3,10)]
    public string sentences;
}

[CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{
    public DialogueTuples[] tuple;
    //public var tupleList = new List<(int, string)>;
    //public System.Tuple<string, string>[] tuples; 
    //public string[] names;

    //[TextArea(3,10)]
    //public string[] sentences;
    //public Sprite artwork;
}


