using System;
using Logic.Attack;
using Logic.Health;
using UnityEngine;

namespace Logic.Monsters
{
    public class MonsterAttack : MonoBehaviour
    {
        private const string PlayerLayerMask = "Player";

        [SerializeField] private MonsterMovement _movement;
        [SerializeField] private MonsterAnimator _animator;
        [SerializeField] private MonsterHealth _health;
        [SerializeField] private float _radius = 5f;

        private BaseAttack _attack;
        private float _nextShootTime;
        private float _shootRate;
        private int _damage;

        private IDamageable _targetDamageable;

        public void Construct(float shootRate, int damage, IDamageable targetDamageable)
        {
            _shootRate = shootRate;
            _damage = damage;
            _targetDamageable = targetDamageable;
        }

        private void Start()
        {
            _attack = new MeleeAttack(_movement, _radius, PlayerLayerMask, _damage);
            _health.Died += OnDied;
        }

        private void OnDestroy()
        {
            _health.Died -= OnDied;
        }

        private void OnDied(GameObject monster)
        {
            enabled = false;
        }

        private void Update()
        {
            if (_targetDamageable.IsDead) return;

            Attack();
        }

        public void AttackAnimationEvent()
        {
            _attack.Attack();
        }

        private void Attack()
        {
            if (!(Time.time > _nextShootTime)) return;

            _animator.AttackAnimation();
            Debug.Log("Attack");

            _nextShootTime = Time.time + 1 / _shootRate;
        }
    }
}