using UnityEngine;
using System.Collections;

public class StartUILoader : MonoBehaviour
{
    [SerializeField] private GameObject startupUI; 
    [SerializeField] private float initialDelay = 2f;
    private bool canCloseUI = false;
    [SerializeField] private Animator animator;

    void Start()
    {
        if (startupUI != null)
        {
            startupUI.SetActive(true);
        }
        StartCoroutine(EnableCloseUIAfterDelay());
        animator.SetBool("IsOpen", false);
        animator.SetBool("IsOpen", true);
    }

    void Update()
    {
        if (startupUI != null && canCloseUI)
        {
            if (Input.anyKeyDown)
            {
                animator.SetBool("IsOpen", false);
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