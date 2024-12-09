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
    
    
    [SerializeField] private TMP_Text currentMpDisplay;
    [SerializeField] private TMP_Text maxMpDisplay;
    
    //mpRegenRate determines how fast MP is recovered each second and mpRegenDelay determines how long the game will wait until it starts to regen MP. 
    [Header("Regeneration Settings")]
    [SerializeField] private float mpRegenRate = 5f; 
    [SerializeField] private float mpRegenDelay = 2f; 
    private float regenCooldown;
    
    void Start()
    {
        MpData.maxMp = 100;
        maxHealth = MpData.maxMp;
        MP = MpData.mp;
    }

    void Update()
    {
        maxMpDisplay.text = MpData.maxMp.ToString();
        currentMpDisplay.text = Mathf.RoundToInt(MpData.mp).ToString();

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
        if (regenCooldown <= 0 && MP < MpData.maxMp) {
            RegenerateMp();
        }
        else {
            regenCooldown -= Time.deltaTime;
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MpDeplete(float mpCost) {
        MP -= mpCost;
        MpData.mp = MP;
        Debug.Log("A pressed, you lose 10 MP");
        Debug.Log($"Player MP: {MP}");
        if (MpData.mp <= 0)
        {
            MpData.mp = 0;
        }
    }
    
    void RegenerateMp()
    {
        MP += mpRegenRate * Time.deltaTime;
        MP = Mathf.Clamp(MP, 0, MpData.maxMp);
        MpData.mp = MP;
    }

}
