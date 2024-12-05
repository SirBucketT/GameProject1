using System.Collections;
using System.Collections.Generic;
using UI.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class MPManager : MonoBehaviour
{ 
    public MP_ScriptableObject MpData;
    
    [SerializeField] private Slider playerMpbar; 
    [SerializeField] private Slider playerMpBarBack;
    [SerializeField] private float maxHealth = 100;
    private float MP;
    private readonly float _lerpSpeed = 0.05f;
    
    
    [SerializeField] private TMP_Text currentExpDisplay;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    void Start()
    {
        MpData.maxMp = 100;
        maxHealth = MpData.maxMp;
        MP = MpData.mp;
    }

    void Update()
    {
        maxMpDisplay.text = MpData.maxMp.ToString();
        currentExpDisplay.text = MpData.mp.ToString();

        //slider code, do not touch
        if (playerMpbar.value != MP){
            playerMpbar.value = MP;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            MpDeplete(10);
        }
        if (playerMpbar.value != playerMpBarBack.value) {
            playerMpBarBack.value = Mathf.Lerp(playerMpBarBack.value, MP, _lerpSpeed); 
        }
        if (MP <= 0) {
            MP = 0;
            //     TODO implement feature that loads MP empty UI elements
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MpDeplete(float mpCost) {
        MP -= mpCost;
        MpData.mp = MP;
        Debug.Log("A pressed, you lose 10 MP");
        Debug.Log($"Player MP: {MP}");
    }

}
