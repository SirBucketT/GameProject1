using UnityEngine;

public class ParentLineGizmo : MonoBehaviour
{
    private void OnDrawGizmos()
    {
        Transform parent = transform.root;

        if (parent != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(transform.position, parent.position);
        }
    }
}