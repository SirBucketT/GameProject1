using UnityEngine;

public class Attributes_Manager : MonoBehaviour
{
  public float health;
  public float attack;
  [SerializeField] private float InvokeAttackDistance = 0.7f;
  private HPManager playerTakeDamage;



 private void Start()
 {
 }

 private void Update()
 {
  
   RaycastHit hit;

  Vector3 fwd = transform.TransformDirection(Vector3.forward);
  
  if (Physics.Raycast(transform.position, fwd, out hit, 10))
  {
   playerTakeDamage.PlayerTakeDamage(attack);
  }
  Debug.Log($"Damage dealt by enemy: {attack} \n Distance = {hit.distance}");
 }
}
