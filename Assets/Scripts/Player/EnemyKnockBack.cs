using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
           public float range = 100f;
           public float KnockbackForce = 250;
           public Camera Cam;
           public GameObject Enemy;

              
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootRaycast();
        }
    }
    void ShootRaycast()
    {
        RaycastHit hit;
        if (Physics.Raycast(Cam.transform.position, Cam.transform.forward, out hit, range))
        {
            KnockBackTarget target = hit.transform.GetComponent<KnockBackTarget>();
            if (target != null)
            {
                Knockback(hit.point);
            }
        }
    }
    void Knockback(Vector3 hitPoint)
    {
        Vector3 knockbackDirection = (Enemy.transform.position - hitPoint).normalized;
        
        Enemy.transform.position += knockbackDirection * Time.deltaTime * KnockbackForce;
    }
}
