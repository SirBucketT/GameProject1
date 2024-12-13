using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject QuitGameUI;
    
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
        QuitGameUI.SetActive(false);
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
        QuitGameUI.SetActive(true);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
        QuitGameUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
