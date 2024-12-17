using System;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] PlayerData gold; 
    [SerializeField] private TMP_Text goldText;

    void Update()
    {
        goldText.text = gold.gold.ToString();
    }
}
