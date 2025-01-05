using UnityEngine;

public class ItemDropManager : MonoBehaviour
{
    private ItemDrop _itemDrop;

    private void Start()
    {
        _itemDrop = GetComponent<ItemDrop>();
    }

    public void DropItems()
    {
        if (_itemDrop != null)
        {
            _itemDrop.DropItems();
        }
    }
}