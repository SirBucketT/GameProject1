using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField] private SO_DropListData _dropList; 
    [SerializeField] private float spawnDelayBetweenItems = 0.5f; 
    
    private void Start()
    {
        SubscribeToEnemyDeath(gameObject);  
    }

    private IEnumerator DropItems()
    {
        foreach (var dropList in _dropList.GetDropList)
        {
            foreach (var itemPrefab in dropList.GetDropList)
            {
                if (itemPrefab != null)
                {
                    GameObject item = Instantiate(
                        itemPrefab,
                        transform.position + GetRandomSpawnOffset(),
                        Quaternion.identity
                    );
                    item.SetActive(true); 
                }
                else
                {
                    Debug.LogWarning("Item prefab is null, skipping.");
                }

                yield return new WaitForSeconds(spawnDelayBetweenItems);
            }
        }
    }

    private void SubscribeToEnemyDeath(GameObject enemyPrefab)
    {
        var healthManager = enemyPrefab.GetComponent<EnemyHealthManager>();
        if (healthManager != null)
        {
            healthManager.OnDeath += OnEnemyDeath;
        }
        else
        {
            Debug.LogWarning("EnemyHealthManager not found on the provided enemy prefab.");
        }
    }

    private void OnEnemyDeath()
    {
        StartCoroutine(DropItems());
    }

    private Vector3 GetRandomSpawnOffset()
    {
        float randomX = Random.Range(-2f, 2f); 
        float randomY = Random.Range(0f, 2f); 
        float randomZ = Random.Range(-2f, 2f); 

        return new Vector3(randomX, randomY, randomZ);
    }
}
