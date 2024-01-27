using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string name;
    [TextArea(3,10)] public string text;

    public DialogueLine(string name, string text){
        this.name = name;
        this.text = text;
    }
}
