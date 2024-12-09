using System;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    public Gold gold; 
    [SerializeField] private TMP_Text goldText;

    void Update()
    {
        goldText.text = gold.gold.ToString();
        
        if (Input.GetKeyUp(KeyCode.B)) {
            gold.GetGold(10);
        }
    }
}
