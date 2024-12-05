using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Player
{
    [CreateAssetMenu(fileName = "ManagerMP", menuName = "ScriptableObjects/ManaPointManager")]
    public class MP_ScriptableObject : ScriptableObject
    {
        public float mp;
        public float maxMp;
    }
}
