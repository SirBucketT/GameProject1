using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DropListBase
{
  [SerializeField] List<GameObject> _dropList =  new List<GameObject>();

  public List<GameObject> GetDropList => _dropList;
}
