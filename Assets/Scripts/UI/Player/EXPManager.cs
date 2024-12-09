using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class EXPManager : MonoBehaviour
{
    [SerializeField] private LevelManagerScriptableObject _levelData;
    [SerializeField] private HPManager hpManager;
    [SerializeField] private HealthbarManager _healthbarManager;
    
    [SerializeField] private Slider playerExpBar;
    [SerializeField] private Slider playerExpBarBack;
    private float maxHealth;
    
    private float _exp;
    private readonly float _lerpSpeed = 0.05f;
    
    [SerializeField] private TMP_Text levelUiDsiplay;
    [SerializeField] private TMP_Text currentExpDisplay;
    [SerializeField] private TMP_Text maxExpDisplay;

    void Start()
    {
        //temporary code to make testing of the game easier, will be changed later
        _levelData.exp = 0;
        _levelData.playerLevel = 0;
        _levelData.maxExp = 100;
        //
        _exp = _levelData.exp;
        maxHealth = _levelData.maxExp;
    }

    void Update()
    {
        levelUiDsiplay.text = _levelData.playerLevel.ToString();
        currentExpDisplay.text = _levelData.exp.ToString();
        maxExpDisplay.text = maxHealth.ToString();
        
        //slider code, do not touch
        if (playerExpBar.value != _exp)
        {
            playerExpBar.value = _exp;
        }

        if (Input.GetKeyUp(KeyCode.S))
        {
            GainExperiancePoints(15);
        }

        if (playerExpBar.value != playerExpBarBack.value)
        {
            playerExpBarBack.value = Mathf.Lerp(playerExpBarBack.value, _exp, _lerpSpeed);
        }
    }
    
    void GainExperiancePoints(float expGain)
    {
        _exp += expGain;
        _levelData.exp = _exp;
        Debug.Log($"S pressed, you gained {expGain} EXP");
        Debug.Log($"Player EXP: {_levelData.minExp}");
        
        while (_exp >= maxHealth)
        {
            _exp -= maxHealth;
            _levelData.playerLevel += 1; 
            maxHealth *= 2;
            hpManager.maxHP *= 1.5f;
            hpManager.currentHP *= 1.3f;
            _healthbarManager.UpdateHealthBarMaxValue();
            Debug.Log($"Max EXP reached, leveling up to: {_levelData.playerLevel}");
        }
        if (_levelData.playerLevel >= _levelData.maxPlayerLevel)
        {
            _levelData.playerLevel = _levelData.maxPlayerLevel;
            return;
        }
        
        _levelData.exp = _exp;
        playerExpBar.maxValue = maxHealth;
        playerExpBarBack.maxValue = maxHealth;
    }
}
