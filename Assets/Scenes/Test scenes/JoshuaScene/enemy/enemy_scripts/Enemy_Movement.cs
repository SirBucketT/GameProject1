using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float rotationSpeed;
    
    private Rigidbody _rigidbody;
    private Player_Awareness_Controller _playerAwarenessController;

    private Vector3 _targetDirection;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _playerAwarenessController = GetComponent<Player_Awareness_Controller>();
    }
    
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAwarenessController.AwareOfPlayer)
        {
            _targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector3.zero)
        {
            return;
        }
        
        Quaternion targetRotation = Quaternion.LookRotation(_targetDirection);
        
        _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector3.zero)
        {
            _rigidbody.linearVelocity = Vector3.zero;
        }
        else
        {
// <<<<<<< HEAD
//             _rigidbody.linearVelocity = transform.forward * speed; 
// =======
//             _rigidbody.linearVelocity = _targetDirection * speed; 
// >>>>>>> 84b5bfe2d1eb7d353214b741670a17f933bbb820
        }
    }
}
