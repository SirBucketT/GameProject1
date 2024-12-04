using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class MPManager : MonoBehaviour
{ 
    [SerializeField] private Slider playerMpbar; 
    [SerializeField] private Slider playerMpBarBack;
    [SerializeField] private float maxHealth = 100;
    private float MP;
    private readonly float _lerpSpeed = 0.05f;
    
    private bool _isPlayerMPempty;
    
    void Start()
    {
        MP = maxHealth;
        _isPlayerMPempty = false;
    }

    void Update()
    {
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
        if (MP <= 0 && !_isPlayerMPempty) {
            _isPlayerMPempty = true;
        //     TODO implement feature that loads MP empty UI elements
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void MpDeplete(float mpCost) {
        MP -= mpCost;
        Debug.Log("A pressed, you lose 10 MP");
        Debug.Log($"Player MP: {MP}");
    }

}
