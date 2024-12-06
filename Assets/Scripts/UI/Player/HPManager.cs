using UnityEngine;


[CreateAssetMenu(fileName = "HP Manager", menuName = "ScriptableObjects/HP Manager")]
public class HPManager : ScriptableObject
{
    public float maxHP;
    public float currentHP;
}
