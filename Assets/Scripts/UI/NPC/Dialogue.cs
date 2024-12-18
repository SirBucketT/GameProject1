using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Dialogue
{
    public string name;
    
    [TextArea(1, 6)]
    
    public string[] sentences;
    
}
