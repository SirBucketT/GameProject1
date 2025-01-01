using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

internal class ItemDrop : MonoBehaviour
{
    [SerializeField] private SO_DropListData _dropList;
    internal void DropItems()
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
            }
        }
    }
    
    private Vector3 GetRandomSpawnOffset()
    {
        float randomX = Random.Range(-2f, 2f); 
        float randomY = Random.Range(-1f, 1f); 
        float randomZ = Random.Range(-2f, 2f); 

        return new Vector3(randomX, randomY, randomZ);
    }
}
