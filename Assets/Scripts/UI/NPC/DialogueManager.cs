using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class DialogueManager : MonoBehaviour
{
    
    private Queue<string> _sentences;
    
    void Start()
    {
        _sentences = new Queue<string>();
    }
}
