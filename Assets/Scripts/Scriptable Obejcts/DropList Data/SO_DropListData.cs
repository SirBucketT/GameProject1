using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropList", menuName = "ScriptableObjects/DropListSO", order = 1)]
public class SO_DropListData : ScriptableObject
{
    [SerializeField] private List<DropList> _dropList = new List<DropList>();
    
}