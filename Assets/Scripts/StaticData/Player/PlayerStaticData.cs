using System;
using Logic.UpgradeSystem;
using UnityEngine;

namespace StaticData.Player
{
    [CreateAssetMenu(fileName = "Player Stats", menuName = "Balance/Player Stats")]
    public class PlayerStaticData : ScriptableObject
    {
        public event Action<UpgradeType> StatsUpgraded;
        
        [SerializeField] private int _health;
        [SerializeField] private int _damage;
        [SerializeField] private float _moveDuration;
        [SerializeField] private float _attackRate;
        [SerializeField] private float _radius;

        public int Health => _health;

        public int Damage => _damage;

        public float MoveDuration => _moveDuration;

        public float AttackRate => _attackRate;

        public float Radius => _radius;

        public void UpgradeHealth(int health)
        {
            _health = health;
            StatsUpgraded?.Invoke(UpgradeType.Health);
        }

        public void UpgradeDamage(int damage)
        {
            _damage = damage;
            StatsUpgraded?.Invoke(UpgradeType.Attack);
        }

        public void UpgradeAttackSpeed(float attackSpeed)
        {
            _attackRate = attackSpeed;
            StatsUpgraded?.Invoke(UpgradeType.AttackSpeed);
        }
    }
 }