using UnityEngine;

public class MainMenuScript : MonoBehaviour
{
    [SerializeField] GameObject credits;
    [SerializeField] GameObject mainMenu;
    
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
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        credits.SetActive(false);
        mainMenu.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
