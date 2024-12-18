using UnityEngine;

public class SwordHandler : MonoBehaviour
{
        [SerializeField] GameObject backAttachPoint;
        [SerializeField] GameObject rightHandAttachPoint;
        [SerializeField] GameObject sword;
        private Animator animator;
        
    
        private bool isSwordInHand = false;

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
            if (Input.GetKeyDown("space"))
            {
                animator.SetTrigger("DrawSword");
            }
        }
}