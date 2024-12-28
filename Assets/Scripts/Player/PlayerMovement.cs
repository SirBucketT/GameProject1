using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Serialization;

[RequireComponent(typeof(LineRenderer))]
public class PlayerMovement : MonoBehaviour
{
    private NavMeshAgent _agent;
    private Animator _animator;
    private LineRenderer _lineRenderer;

    [SerializeField] private GameObject clickEffect; 

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
        _lineRenderer = GetComponent<LineRenderer>();
        
        _lineRenderer.startWidth = 0.1f;
        _lineRenderer.endWidth = 0.1f;
        _lineRenderer.positionCount = 0;
    }

    void Update()
    {
        UpdatePathLine();

        if (Vector3.Distance(transform.position, _agent.transform.position) > 0.01f)
        {
            _agent.transform.position = transform.position;
        }

        float normalizedSpeed = _agent.velocity.magnitude / _agent.speed;
        _animator.SetFloat("Velocity", normalizedSpeed);

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButton(0))
        {
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _agent.SetDestination(hitInfo.point);
                
                //plays click effect and destroys the instance of the effect after x amount of seconds.
                //this to save on performance and to avoid having hundreds of instances of the effect created after a while in game
                if (clickEffect != null)
                {
                    GameObject effectInstance = Instantiate(clickEffect, hitInfo.point, Quaternion.identity);
                    Destroy(effectInstance, 0.5f);
                    
                    //Instantiate(clickEffect, hitInfo.point, Quaternion.identity);
                    //Destroy(clickEffect);
                }
            }
        }
    }

    private void UpdatePathLine()
    {
        if (_agent.hasPath)
        {
            _lineRenderer.positionCount = _agent.path.corners.Length;
            _lineRenderer.SetPositions(_agent.path.corners);
        }
        else
        {
            _lineRenderer.positionCount = 0;
        }
    }
}