using System.Collections;
using UnityEngine;

public class GetHitEffect : MonoBehaviour
{
    [SerializeField] Renderer _renderer; 
    [SerializeField] Material _material; 
    [SerializeField] float _effectDuration = 0.2f;

    [SerializeField] private Color _hitColor = Color.grey;
    private Color _originalColor; 

    void Start()
    {
        if (_renderer == null)
        {
            _renderer = GetComponentInChildren<Renderer>();
        }
        _material = _renderer.material;

        _originalColor = _material.color;
    }

    public void TriggerHitEffect()
    {
        if (gameObject.activeInHierarchy)
        {
            StopAllCoroutines();
            StartCoroutine(HitEffectCoroutine());
        }
    }

    private IEnumerator HitEffectCoroutine()
    {
        _material.color = _hitColor;

        yield return new WaitForSeconds(_effectDuration);
        
        _material.color = _originalColor;
    }
}