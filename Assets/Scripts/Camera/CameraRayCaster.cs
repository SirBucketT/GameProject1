using System;
using UnityEngine;

public class CameraRayCaster : MonoBehaviour
{
        [SerializeField] private float rayDistance = 100f;
        [SerializeField] private LayerMask layerMask;
        
        private Camera cam;

        private void Awake()
        {
                cam = Camera.main;
        }

        private void Update()
        {
                if (!Input.GetMouseButtonDown(0))
                        return;
                
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, rayDistance, layerMask, QueryTriggerInteraction.Ignore))
                {
                        Debug.DrawLine(ray.origin, hit.point, Color.yellow, 0.5f);
                        if (hit.collider.gameObject.TryGetComponent<IInteractable>(out var interactable))
                        {
                                interactable.Interact();
                        }
                }
                else
                {
                        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red, 0.5f);
                }
                
        }
        
}      