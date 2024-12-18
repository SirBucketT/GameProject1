using UnityEngine;

public class SwordHandler : MonoBehaviour
{
    [SerializeField] GameObject backAttachPoint;
    [SerializeField] GameObject rightHandAttachPoint;
    [SerializeField] GameObject sword;
    private Animator animator;
    private float animationTimer;
    private float switchPoint;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleSword();
        }
    }

    void ToggleSword()
    {
        if (!animator.GetBool("SwordDrawn"))
        {
            animator.SetBool("SwordDrawn", true);
            sword.transform.SetParent(rightHandAttachPoint.transform);
            sword.transform.localPosition = new Vector3(0.2f, 0, 0);
            sword.transform.localRotation = Quaternion.Euler(0, 0, -300);
        }
        else
        {
            animator.SetBool("SwordDrawn", false);
            ;
            if (animator.GetFloat("Speed") >= 0.1)
            {
                sword.transform.SetParent(backAttachPoint.transform);
            }
            
        }
    }
    
    
}