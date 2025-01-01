using System.Collections;
using UnityEngine;

public class Destructible : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject BoxUI;
    [SerializeField] private GameObject destructibleParts;
    [SerializeField] private Collider destructibleCollider;
    [SerializeField] private MeshRenderer meshRenderer;
    [Header("Explosion Settings")]
    [SerializeField] private float explosionForce;
    [SerializeField] private float explosionRadius;
    [SerializeField] private float pieceDuration;

    private ItemDrop _itemDrop;
    public bool IsPlayerWithinRange { get; private set; }

    private void Awake()
    {
        _itemDrop = GetComponent<ItemDrop>();
    }

    public void Interact()
    {
        if (IsPlayerWithinRange)
        {
            Break();
        }
    }

    public void Break()
    {
        if (_itemDrop != null)
        {
            _itemDrop.DropItems();
        }

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

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        IsPlayerWithinRange = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player"))
        {
            return;
        }
        IsPlayerWithinRange = false;
    }
}
