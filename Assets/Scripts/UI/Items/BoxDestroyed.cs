using UnityEngine;
using System.Collections;
using UnityEngine.Animations;

public class BoxDestroyed : MonoBehaviour
{
    [SerializeField] private GameObject box;
    [SerializeField] private float initialDelay;
    private bool uiCloser = false; 
    [SerializeField] private Animator animator;

    void Start() {
        if (box != null) {
            box.SetActive(true);
            animator.SetBool("IsOpen", true);
        }

        StartCoroutine(CloseBox());
    }
    void Update() {
        if (box != null && uiCloser) {
            box.SetActive(false);
            animator.SetBool("IsOpen", false);
        }
    }
    
    private IEnumerator CloseBox() {
        yield return new WaitForSeconds(initialDelay);
        uiCloser = true;
    }
}
