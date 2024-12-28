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
            if (Input.anyKeyDown || IsPlayerMoving())
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

    private bool IsPlayerMoving()
    {
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null && rb.linearVelocity.magnitude > 0.1f)
            {
                return true;
            }
        }
        return false;
    }
}