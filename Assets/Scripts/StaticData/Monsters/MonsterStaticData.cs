using Logic.Monsters;
using UnityEngine;

namespace StaticData.Monsters
{
    [CreateAssetMenu(fileName = "Monsters Stats", menuName = "Balance / Monster Stats")]
    public class MonsterStaticData : ScriptableObject
    {
        [SerializeField] private MonsterType _monsterType;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private int _damage;
        [SerializeField] private int _health;
        [SerializeField] private float _attackSpeed;
        
        [SerializeField] private GameObject _monsterPrefab;

        public MonsterType MonsterType => _monsterType;

        public float MoveSpeed => _moveSpeed;

        public int Damage => _damage;

        public int Health => _health;

        public float AttackSpeed => _attackSpeed;

        public GameObject MonsterPrefab => _monsterPrefab;
    }
}