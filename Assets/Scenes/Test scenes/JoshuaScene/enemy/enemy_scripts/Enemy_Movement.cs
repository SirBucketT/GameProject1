using UnityEngine;

public class Enemy_Movement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    [SerializeField]
    private float rotationSpeed;

    private Rigidbody _rigidbody;
    private Player_Awareness_Controller _playerAwarenessController;

    private Vector2 targetDirection;

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
            targetDirection = _playerAwarenessController.DirectionToPlayer;
        }
        else
        {
            targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (targetDirection == Vector2.zero)
        {
            return;
        }
        Quaternion targetDirection = Quaternion.LookRotation(transform.forward, _targerDirection);
        Quaternion rotation = Quaternion.RotateTowards(transform.rotation, targetDirection, rotationSpeeed * Time.deltaTime);
        
        _rigidbody.SetRotation(rotation);
    }

    private void SetVeclocity()
    {
        if (targetDirection == Vector2.zero)
        {
            _rigidbody.linearVelocity = Vector2.zero;
        }
        else
        {
            _rigidbody.linearVelocity = transform.forward * speed; 
        }
    }
}
