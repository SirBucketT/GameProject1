 using UnityEngine;

 public class Camera_Follow : MonoBehaviour
 {
     [Header("Camera Controller")]
     public Transform target; 

     public Vector3 offset = new Vector3(0, 5f, -10f); 
     public float followSpeed = 5f; 

     private void Update()
     {
         
         Vector3 targetPosition = target.position + offset;

         
         transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);

         
         transform.LookAt(target);
     }
 }

