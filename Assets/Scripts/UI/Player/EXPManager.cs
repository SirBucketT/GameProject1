using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class EXPManager : MonoBehaviour
{
    private static LevelManagerScriptableObject _levelData;
    
    [SerializeField] private Slider playerExpBar;
    [SerializeField] private Slider playerExpBarBack;
    private float maxHealth = _levelData.maxExp;
    private float minHealth = _levelData.minExp;
    
    private float _exp;
    private readonly float _lerpSpeed = 0.05f;
    
    [SerializeField] private TMP_Text levelUiDsiplay;

    private bool isPlayerExpFull;

    void Start()
    {
        _exp = _levelData.exp;
        isPlayerExpFull = false;
        //temporary test code, will implement a scriptable object to store current level later.
    }

    void Update()
    {
        levelUiDsiplay.text = _levelData.playerLevel.ToString();
        //slider code, do not touch
        if (playerExpBar.value != _exp)
        {
            playerExpBar.value = _exp;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GainExperiancePoints(10);
        }

        if (playerExpBar.value != playerExpBarBack.value)
        {
            playerExpBarBack.value = Mathf.Lerp(playerExpBarBack.value, _exp, _lerpSpeed);
        }

        if (_exp >= maxHealth)
        {
            isPlayerExpFull = true;
            _levelData.playerLevel += 1; 
            _levelData.maxExp *= 2;
            maxHealth *= 2;
            minHealth = 0;
            Debug.Log($"Max EXP reached, leveling up to: {_levelData.playerLevel}");
        }
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void GainExperiancePoints(float expGain)
    {
        _exp += expGain;
        _exp = _levelData.exp;
        Debug.Log($"S pressed, you gained {expGain} EXP");
        Debug.Log($"Player EXP: {_levelData.minExp}");
        
        //if (_levelData.minExp >= _levelData.maxExp && _levelData.playerLevel < _levelData.maxPlayerLevel)
        //{
            //_levelData.playerLevel += 1; 
            //_levelData.maxExp *= 2;
            //_levelData.minExp *= 2;
            //Debug.Log($"Max EXP reached, leveling up to: {_levelData.playerLevel}");
        //}
    }
}
