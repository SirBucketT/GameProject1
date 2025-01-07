using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    private Animator _animator;
    public GameObject _leftFoot;
    private Collider _leftFootCollider;
    private EnemyKnockBack enemyKnockBack;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _leftFoot = GameObject.FindGameObjectWithTag("Left Foot");

        if (_leftFootCollider != null)
        {
            _leftFootCollider = _leftFoot.GetComponent<Collider>();
        }
        _animator.SetBool("IsAlive", true);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            _animator.SetTrigger("Dab");
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            _animator.SetTrigger("Kick");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            _animator.SetTrigger("Slash");
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (collision.contacts[0].thisCollider.gameObject == _leftFoot)
            {
                Debug.Log("Foten träffade en fiende!");
                enemyKnockBack.GetKicked();
            }
        }
    }
}
