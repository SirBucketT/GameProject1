using UnityEngine;

[CreateAssetMenu(fileName = "ObjectDestroyData", menuName = "ScriptableObjects/ObjectDestroyData", order = 1)]
public class so_ObjectDestroyData : ScriptableObject
{
    public bool isDestroyedOnContact;
    public bool isDisabledOnContact;
}