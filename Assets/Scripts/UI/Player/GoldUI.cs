using System;
using UnityEngine;
using TMPro;

public class GoldUI : MonoBehaviour
{
    [SerializeField] PlayerData playerData; 
    [SerializeField] private TMP_Text goldText;

    void Update()
    {
        goldText.text = playerData.gold.ToString();
    }
}
