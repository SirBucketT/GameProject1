using System;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] PlayerData playerData; 
    [SerializeField] private TMP_Text goldText;

    void Update()
    {
        if (goldText.text != null)
        {
            goldText.text = playerData.gold.ToString();
        }
    }
}
