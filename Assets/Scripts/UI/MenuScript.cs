using UnityEngine;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameUI;
    
    [SerializeField] private string mainMenu;
    [SerializeField] private string exitGame;


     void Start()
     {
         Time.timeScale = 1.0f;
         pauseMenuUI.SetActive(false);
         gameUI.SetActive(true);
     }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameUI.SetActive(true);
    }
    
    private void PauseGame()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        Time.timeScale = pauseMenuUI.activeSelf ? 0 : 1;
        gameUI.SetActive(!pauseMenuUI.activeSelf);
    }
    
    // public void startGameButton()
    // {
    //     SceneManager.LoadScene();
    // }
    
    public void QuitGameButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit button pressed");
#endif
        Application.Quit();
    }
}
