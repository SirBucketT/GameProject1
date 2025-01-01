using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropListBase", menuName = "ScriptableObjects/DropListSO", order = 1)]
public class SO_DropListData : ScriptableObject
{
    [SerializeField] private List<DropListBase> _dropList = new List<DropListBase>();
    
    public List<DropListBase> GetDropList => _dropList;
}