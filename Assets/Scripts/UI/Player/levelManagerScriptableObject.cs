using UnityEngine;

namespace UI.Player
{
    [CreateAssetMenu(fileName = "levelManager", menuName = "ScriptableObjects/levelManager")]
    public class LevelManagerScriptableObject : ScriptableObject
    {
        public int playerLevel;
        public int maxPlayerLevel;
        public float minExp;
        public float maxExp;
        public float exp;
    }
}
