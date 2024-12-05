using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EXPManager : MonoBehaviour
{ 
    [SerializeField] private Slider playerExpBar; 
    [SerializeField] private Slider playerExpBarBack;
    [SerializeField] private float maxHealth = 100;
    private float _exp;
    private readonly float _lerpSpeed = 0.05f;
    
    private bool _isPlayerExpFull;
    
    void Start()
    {
        _exp = maxHealth;
        _isPlayerExpFull = false;
    }

    void Update()
    {
        //slider code, do not touch
        if (playerExpBar.value != _exp){
            playerExpBar.value = _exp;
        }
        if (Input.GetKeyUp(KeyCode.S)) {
            GainExperiancePoints(10);
        }
        if (playerExpBar.value != playerExpBarBack.value) {
            playerExpBarBack.value = Mathf.Lerp(playerExpBarBack.value, _exp, _lerpSpeed); 
        }
        if (_exp <= 0 && !_isPlayerExpFull) {
            _isPlayerExpFull = true;
        //     TODO implement feature that loads MP empty UI elements
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void GainExperiancePoints(float expGain) {
        _exp += expGain;
        Debug.Log("S pressed, you gained 10 EXP");
        Debug.Log($"Player EXP: {_exp}");
    }

}
