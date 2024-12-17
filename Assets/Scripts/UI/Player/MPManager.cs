using System.Collections;
using System.Collections.Generic;
using UI.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using TMPro;

public class MPManager : MonoBehaviour
{ 
    public PlayerData MpData;
    
    [SerializeField] private Slider playerMpbar; 
    [SerializeField] private Slider playerMpBarBack;
    private readonly float _lerpSpeed = 0.05f;
    
    
    [SerializeField] private TMP_Text currentMpDisplay;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    //mpRegenRate determines how fast MP is recovered each second and mpRegenDelay determines how long the game will wait until it starts to regen MP. 
    [Header("Regeneration Settings")]
    [SerializeField] private float mpRegenRate = 5f; 
    [SerializeField] private float mpRegenDelay = 2f; 
    private float _regenCooldown;
    
    void Start()
    {
        
    }

    void Update()
    {
        maxMpDisplay.text = MpData.maxMp.ToString();
        currentMpDisplay.text = Mathf.RoundToInt(MpData.currentMp).ToString();

        //slider code, do not touch
        if (playerMpbar.value != MpData.currentMp){
            playerMpbar.value = MpData.currentMp;
        }
        if (Input.GetKeyUp(KeyCode.A)) {
            MpDeplete(10);
        }
        if (playerMpbar.value != playerMpBarBack.value) {
            playerMpBarBack.value = Mathf.Lerp(playerMpBarBack.value, MpData.currentMp, _lerpSpeed); 
        }
        
        if (MpData.currentMp <= 0) {
            MpData.currentMp = 0;
            //     TODO implement feature that loads MP empty UI elements
        }
        if (_regenCooldown <= 0 && MpData.currentMp < MpData.maxMp) {
            RegenerateMp();
        }
        else {
            _regenCooldown -= Time.deltaTime;
        }
    }
    
    
    
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MpDeplete(float mpCost) {
        MpData.currentMp -= mpCost;
        Debug.Log($"Player MP: {MpData.currentMp}");
        if (MpData.currentMp <= 0)
        {
            MpData.currentMp = 0;
        }
    }
    
    void RegenerateMp()
    {
        MpData.currentMp += mpRegenRate * Time.deltaTime;
        MpData.currentMp = Mathf.Clamp(MpData.currentMp, 0, MpData.maxMp);
        MpData.currentMp = MpData.currentMp;
    }

}
