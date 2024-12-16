using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeTest : MonoBehaviour
{
        public void ChangeScene()
        {
            var nextScene = SceneManager.GetActiveScene().buildIndex + 1;
            
            SceneManager.LoadSceneAsync(nextScene, LoadSceneMode.Additive);
        }
    
}
