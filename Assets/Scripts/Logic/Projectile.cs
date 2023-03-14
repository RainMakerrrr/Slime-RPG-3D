using System;
using Logic.Health;
using UnityEngine;

namespace Logic
{
    public class Projectile : MonoBehaviour
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private float _force;

        private int _damage;

        public void Shoot(Vector3 direction)
        {
            _rigidbody.AddForce(direction * _force, ForceMode.Impulse);
        }

        public void SetDamage(int damage) => _damage = damage;

        private void OnTriggerEnter(Collider other)
        {
            var damageable = other.GetComponent<IDamageable>();

            if (damageable != null)
            {
                damageable.TakeDamage(_damage);
                Destroy(gameObject);
            }
        }
    }
}