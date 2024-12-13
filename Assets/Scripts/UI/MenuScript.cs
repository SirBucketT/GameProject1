using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] public GameObject gameOverMenuUI;
    [SerializeField] private GameObject confirmQuitUI;


     void Start()
     {
         Time.timeScale = 1.0f;
         pauseMenuUI.SetActive(false);
         gameOverMenuUI.SetActive(false);
         confirmQuitUI.SetActive(false);
         gameUI.SetActive(true);
         
     }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    private void PauseGame()
    {
        pauseMenuUI.SetActive(!pauseMenuUI.activeSelf);
        Time.timeScale = pauseMenuUI.activeSelf ? 0 : 1;
        gameUI.SetActive(!pauseMenuUI.activeSelf);
    }

    public void ResumeGame()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameUI.SetActive(true);
    }
    
    public void QuitGameButton()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        Debug.Log("Quit button pressed");
    #endif
        Application.Quit();
    }
    
    
    public void MainMenuButton()
    {
         SceneManager.LoadScene(0);
    }

    public void RestartGameButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
}
