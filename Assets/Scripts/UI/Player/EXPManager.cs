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
    [SerializeField] private float minHealth = 100;
    public float exp;
    private readonly float _lerpSpeed = 0.05f;

    public int playerLevel = 100;

    private bool _isPlayerExpFull;

    void Start()
    {
        exp = minHealth;
        _isPlayerExpFull = false;
        
        //temporary test code, will implement a scriptable object to store current level later.
        playerLevel = 1; //SO_levelManager.CurrentLevel();
    }

    void Update()
    {
        //slider code, do not touch
        if (playerExpBar.value != exp)
        {
            playerExpBar.value = exp;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GainExperiancePoints(10);
        }

        if (playerExpBar.value != playerExpBarBack.value)
        {
            playerExpBarBack.value = Mathf.Lerp(playerExpBarBack.value, exp, _lerpSpeed);
        }

        if (exp >= maxHealth && !_isPlayerExpFull)
        {
            _isPlayerExpFull = true;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void GainExperiancePoints(float expGain)
    {
        exp += expGain;
        Debug.Log("S pressed, you gained 10 EXP");
        Debug.Log($"Player EXP: {exp}");

        if (exp >= maxHealth)
        {
            playerLevel += 1;
            maxHealth *= 2;
            exp = minHealth;
            Debug.Log($"Max EXP reached, leveling up to: {playerLevel}");
            _isPlayerExpFull = false;
        }

    }
}
