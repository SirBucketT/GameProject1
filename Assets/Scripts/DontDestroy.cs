using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    private void DontDestroyOnLoad()
    {
        DontDestroyOnLoad(gameObject);
    }
}
