using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float rotationSpeed;
    
    private Rigidbody _rigidbody;
    private Player_Awareness_Controller _playerAwarenessController;

    private Vector2 _targetDirection;

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
        if (_targetDirection == Vector2.zero)
        {
            return;
        }
        // Quaternion targetDirection = Quaternion.LookRotation(transform.up, _targetDirection);
        // Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetDirection, rotationSpeed * Time.deltaTime);
        // _rigidbody.SetRotation(rotation);

        Vector3 targetDirection = new Vector3(_targetDirection.x, 0, _targetDirection.y);
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        
        _rigidbody.MoveRotation(Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime));
        
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector3.zero;
        }
        else
        {
            _rigidbody.velocity = transform.forward * speed; 
        }
    }
}
