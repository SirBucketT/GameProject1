using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject quitGameUI;
    
    public void PlayGameButton()
    {
        SceneManager.LoadScene(1);
    }
    
    public void OpenCreditsButton()
    {
        credits.SetActive(true);
        mainMenu.SetActive(false);
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
        quitGameUI.SetActive(true);
        mainMenu.SetActive(false);
    }
    
    void Start()
    {
        Time.timeScale = 1.0f;
        credits.SetActive(false);
        mainMenu.SetActive(true);
        quitGameUI.SetActive(false);
    }
}
