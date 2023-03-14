using System;
using Logic.Monsters;
using UnityEngine;

namespace Logic.Health
{
    public class MonsterHealth : MonoBehaviour, IDamageable
    {
        [SerializeField] private MonsterAnimator _animator;


        public int Max { get; private set; }

        public event Action<int> TookDamage;
        public event Action<GameObject> Died;

        private Collider _collider;
        public int Current { get; private set; }
        public bool IsDead => Current <= 0;

        public void Construct(int max)
        {
            Max = max;
            Current = max;
        }

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;

            _animator.TakeDamageAnimation();

            TookDamage?.Invoke(damage);

            if (IsDead)
                Die();
        }

        private void Die()
        {
            _animator.DieAnimation();
            _collider.enabled = false;
            Died?.Invoke(gameObject);

            Destroy(gameObject, 1.5f);
        }
    }
}