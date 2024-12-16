using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject quitGameUI;
    [SerializeField] GameObject settingsMenu;
    [SerializeField] GameObject howToPlay;
    
    public void PlayGameButton()
    {
        SceneManager.LoadScene(2);
    }
    
    public void OpenTutorial()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        quitGameUI.SetActive(false);
        settingsMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void CloseTutorial()
    {
        mainMenu.SetActive(true);
        howToPlay.SetActive(false);
    }
    
    public void OpenCreditsButton()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
        quitGameUI.SetActive(false);
        settingsMenu.SetActive(false);
        howToPlay.SetActive(false);
    }
   
    public void CloseCreditsButton()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void CloseQuitButton()
    {
        quitGameUI.SetActive(false);
        mainMenu.SetActive(true);
    }
    
    public void QuitGameButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit button pressed");
    #endif
        Application.Quit();
    }

    public void OpenQuitButton()
    {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        quitGameUI.SetActive(true);
        settingsMenu.SetActive(false);
        howToPlay.SetActive(false);
        
    }
    
    public void CloseSettingsMenu() {
        settingsMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void OpenSettingsMenu() {
        credits.SetActive(false);
        mainMenu.SetActive(false);
        quitGameUI.SetActive(false);
        settingsMenu.SetActive(true);
        howToPlay.SetActive(false);
    }
    
    void Start()
    {
        Time.timeScale = 1.0f;
        credits.SetActive(false);
        mainMenu.SetActive(true);
        quitGameUI.SetActive(false);
        howToPlay.SetActive(false);
    }
}
