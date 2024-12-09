using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float maxSpeed = 5f;          // Maximum movement speed
    [SerializeField] private float accelerationFactor = 2f; // Acceleration factor
    [SerializeField] private float deceleration = 10f;      // Deceleration when not moving
    [SerializeField] private Animator animator;            // Animator for movement
    [SerializeField] private LayerMask groundLayer;         // Layer to detect ground for mouse click

    private Rigidbody rb;
    private Vector3 targetPosition;
    private Vector3 movementDirection;
    private float currentSpeed = 0f;
    private Vector2 lastMousePosition;
    private bool isDragging = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        HandleInput();

        // Update the animator's "Velocity" parameter based on current speed
        UpdateAnimator();
    }

    void FixedUpdate()
    {
        // Move the player if dragging, otherwise apply deceleration
        if (isDragging)
        {
            MoveTowardsTarget();
        }
        else
        {
            Decelerate();
        }
    }

    void HandleInput()
    {
        if (Input.GetMouseButtonDown(0)) // Left click to start dragging
        {
            lastMousePosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging) // While holding the left mouse button
        {
            HandleMouseDrag();
        }
        else
        {
            isDragging = false;
        }

        if (Input.GetMouseButtonUp(0)) // Release mouse button
        {
            isDragging = false;
        }
    }

    void HandleMouseDrag()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, groundLayer))
        {
            // Get the target position where the player should move to
            targetPosition = hit.point;

            // Calculate movement direction based on mouse drag
            Vector2 currentMousePosition = Input.mousePosition;
            Vector2 dragDelta = currentMousePosition - lastMousePosition;
            movementDirection = (targetPosition - transform.position).normalized;

            // Calculate speed based on the drag magnitude, smooth it over time for acceleration
            float dragMagnitude = dragDelta.magnitude;
            currentSpeed = Mathf.Clamp(currentSpeed + dragMagnitude * accelerationFactor * Time.deltaTime, 0, maxSpeed);

            // Store the last mouse position to calculate the next delta
            lastMousePosition = currentMousePosition;
        }
    }

    void MoveTowardsTarget()
    {
        // Move the player towards the target position with current speed
        Vector3 newPosition = Vector3.MoveTowards(transform.position, targetPosition, currentSpeed * Time.fixedDeltaTime);
        rb.MovePosition(newPosition);
    }

    void Decelerate()
    {
        // If player stops dragging, decelerate the movement smoothly
        if (currentSpeed > 0)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0f, deceleration * Time.fixedDeltaTime);
            rb.MovePosition(transform.position + movementDirection * currentSpeed * Time.fixedDeltaTime);
        }
        else
        {
            movementDirection = Vector3.zero;
        }
    }

    void UpdateAnimator()
    {
        // Update the "Velocity" parameter based on current speed, from 0 to 1 range
        float velocity = Mathf.InverseLerp(0f, maxSpeed, currentSpeed);
        animator.SetFloat("Velocity", velocity);
    }
}
