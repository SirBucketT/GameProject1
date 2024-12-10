using UnityEngine;

public class Attributes_Manager : MonoBehaviour
{
 public float health;
 public float attack;


 public HPManager playerTakeDamage;

 private void Start()
 {
  playerTakeDamage = new();
  playerTakeDamage.TakeDamage(5);
 }

 private void Update()
 {

  CalculateDistance();


 }

 void CalculateDistance()
 {
  Vector3 fwd = transform.TransformDirection(Vector3.forward);

  if (Physics.Raycast(transform.position, fwd, 10))
  {
   Debug.Log($"Distance to player is: {fwd}");
  }
 }
}
