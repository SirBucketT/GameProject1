using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UI.Player;

public class EXPManager : MonoBehaviour
{
    [SerializeField] PlayerData playerData;
    [Header("Front and back slider for UI sliders")]
    [SerializeField] public Slider playerExpBar;
    [SerializeField] public Slider playerExpBarBack;
    
    private readonly float _lerpSpeed = 0.05f;
    
    [Header("UI Text Elements")]
    [SerializeField] private TMP_Text levelUiDsiplay;
    [SerializeField] private TMP_Text currentExpDisplay;
    [SerializeField] private TMP_Text maxExpDisplay;

    void Start()
    {
        //temporary code to make testing of the game easier, will be changed later
        playerData.minExp= 0;
        playerData.playerLevel = 0;
        playerData.maxExp = 100;
        playerData.currentExp = playerData.minExp;
    }

    void Update()
    {
        levelUiDsiplay.text = playerData.playerLevel.ToString();
        currentExpDisplay.text = playerData.currentExp.ToString();
        maxExpDisplay.text = playerData.maxExp.ToString();
        
        //slider code, do not touch
        if (playerExpBar.value != playerData.currentExp)
        {
            playerExpBar.value = playerData.currentExp;
        }

        if (playerExpBar.value != playerExpBarBack.value)
        {
            playerExpBarBack.value = Mathf.Lerp(playerExpBarBack.value, playerData.currentExp, _lerpSpeed);
        }
    }
    
    public void UpdateEXPDisplay()
    {
        playerExpBar.maxValue = playerData.maxExp;
        playerExpBar.value = playerData.currentExp;
        playerExpBarBack.value = playerData.currentHealth;
    }
}
