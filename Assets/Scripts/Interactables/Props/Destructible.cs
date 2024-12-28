using System.Collections;
using UnityEngine;

public class Destructible : MonoBehaviour, IInteractable
{
    [SerializeField] GameObject BoxUI;
    [SerializeField] GameObject destructibleParts;
    [SerializeField] Collider destructibleCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [Header("Explosion Settings")]
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float pieceDuration;
    
    public bool IsPlayerWithinRange { get; private set; }
    
    public void Interact()
    {
        if (IsPlayerWithinRange)
            Break();
    }

    public void Break()
    {
        DisableMainModel();
        EnableBrokenPieces();
        AddExplosiveForceToPieces();
        StartCoroutine(DisableRoutine());
        BoxUI.SetActive(true);
    }
    
    private IEnumerator DisableRoutine()
    {
        yield return new WaitForSeconds(pieceDuration);
        gameObject.SetActive(false);
    }

    public void AddExplosiveForceToPieces()
    {
        var pieces = destructibleParts.GetComponentsInChildren<Rigidbody>();
        foreach (var piece in pieces)
        {
            piece.AddExplosionForce(explosionForce, transform.position, explosionRadius);
        }
    }

    private void EnableBrokenPieces()
    {
        destructibleParts.SetActive(true);
    }

    private void DisableMainModel()
    {
        destructibleCollider.enabled = false;
        meshRenderer.enabled = false;
    }


    public void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        IsPlayerWithinRange = true;
    }

    public void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
            return;
        IsPlayerWithinRange = false;
    }

}

