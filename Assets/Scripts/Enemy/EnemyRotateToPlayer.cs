using UnityEngine;

public class EnemyRotateToPlayer : MonoBehaviour
{
    [SerializeField]
  public Transform Player;
 
    void Update()
    {
     	Vector3 direction = Player.position - transform.position;
         
         direction.y = 0;
         
         transform.rotation = Quaternion.LookRotation(direction);
   
    }
}
