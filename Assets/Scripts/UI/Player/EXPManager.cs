using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class EXPManager : MonoBehaviour
{
    public LevelManagerScriptableObject _levelData;
    
    [SerializeField] private Slider playerExpBar;
    [SerializeField] private Slider playerExpBarBack;
    private float maxHealth;
    private float minHealth;
    
    private float _exp;
    private readonly float _lerpSpeed = 0.05f;
    
    [SerializeField] private TMP_Text levelUiDsiplay;

    private bool isPlayerExpFull;

    void Start()
    {
        _exp = _levelData.exp;
        maxHealth = _levelData.maxExp;
        minHealth = _levelData.minExp;
        isPlayerExpFull = false;
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
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    void GainExperiancePoints(float expGain)
    {
        _exp += expGain;
        _levelData.exp = _exp;
        Debug.Log($"S pressed, you gained {expGain} EXP");
        Debug.Log($"Player EXP: {_levelData.minExp}");
        
        if (_exp >= maxHealth)
        {
            isPlayerExpFull = true;
            _levelData.playerLevel += 1; 
            _levelData.maxExp *= 2;
            maxHealth *= 2;
            minHealth = 0;
            Debug.Log($"Max EXP reached, leveling up to: {_levelData.playerLevel}");
            isPlayerExpFull = false;
        }
    }
}
