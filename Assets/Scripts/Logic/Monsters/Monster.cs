using UnityEngine;

namespace Logic.Monsters
{
    public class Monster : MonoBehaviour
    {
        [SerializeField] private MonsterType _type;

        public MonsterType Type => _type;
    }
}