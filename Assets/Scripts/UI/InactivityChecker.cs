using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class InactivityChecker : MonoBehaviour
{
    [SerializeField] private float secondsToWait = 5f; 
    private float inactivityTimer = 0f;
    private bool hasBeenInactive = true;

    [SerializeField] private GameObject popupManagerGameObject; 

    void Start()
    {
        hasBeenInactive = false;
        if (popupManagerGameObject != null) {
            popupManagerGameObject.SetActive(false);
        }
    }

    void Update() {
        
        if (Input.anyKey || Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0) {
            inactivityTimer = 0f;
            if (popupManagerGameObject != null) {
                popupManagerGameObject.SetActive(false);
            }
        }
        else {
            inactivityTimer += Time.deltaTime;
        }
        if (inactivityTimer >= secondsToWait && popupManagerGameObject != null && !popupManagerGameObject.activeSelf) {
            popupManagerGameObject.SetActive(true);
        }
    }
}
