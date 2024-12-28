using UnityEngine;
using System.Collections;

public class StartUILoader : MonoBehaviour
{
    [SerializeField] private GameObject startupUI; 
    [SerializeField] private float initialDelay = 2f;
    private bool canCloseUI = false;

    void Start()
    {
        if (startupUI != null)
        {
            startupUI.SetActive(true);
        }
        StartCoroutine(EnableCloseUIAfterDelay());
    }

    void Update()
    {
        if (startupUI != null && canCloseUI)
        {
            if (Input.anyKeyDown)
            {
                Destroy(startupUI);
            }
        }
    }

    private IEnumerator EnableCloseUIAfterDelay()
    {
        yield return new WaitForSeconds(initialDelay);
        canCloseUI = true;
    }
}