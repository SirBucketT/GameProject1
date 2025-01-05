using System.Collections;
using UnityEngine;

public class EnemyGetHitEffect : MonoBehaviour
{
    [SerializeField] Renderer _renderer; 
    [SerializeField] Material _material; 
    [SerializeField] private Color _hitColor = Color.grey;
    [Header("Default Values")]
    [SerializeField] private bool _forceDefaultValue;
    [SerializeField] float _effectDurationDefault = 0.5f;

    private Color _originalColor; 
    private float _effectDuration;

    private EnemyTakeDamageCooldown _enemyTakeDamageCooldown;

    void Start()
    {
        if (_renderer == null)
        {
            _renderer = GetComponentInChildren<Renderer>();
        }
        _material = _renderer.material;

        _originalColor = _material.color;
        
        _enemyTakeDamageCooldown = FindObjectOfType<EnemyTakeDamageCooldown>();
        if (!_forceDefaultValue && _enemyTakeDamageCooldown != null )
        {
            TakeDamageDuration();
        }
        else
        {
            _effectDuration = _effectDurationDefault;
        }

    }

    private void TakeDamageDuration()
    {
        if (_enemyTakeDamageCooldown != null)
        {
            _effectDuration = _enemyTakeDamageCooldown.GetDamageCooldown();
        }
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