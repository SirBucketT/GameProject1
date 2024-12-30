using System;
using UnityEngine;

public class MinimapFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Animator mapAnimator;

    void Start() {
        mapAnimator.SetBool("Map", false);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            if (mapAnimator != null) {
                bool currentState = mapAnimator.GetBool("Map");
                mapAnimator.SetBool("Map", !currentState);
            }
        }
    }
    void LateUpdate(){
        if (player != null) {
            Vector3 newPosition = player.position;
            newPosition.y = transform.position.y;
            transform.position = newPosition;
            
            transform.rotation = Quaternion.Euler(90f, 0f, 0f);
        }
    }
}