using System;
using Logic.UpgradeSystem;
using StaticData.Player;
using UnityEngine;

namespace Logic.Health
{
    public class PlayerHealth : MonoBehaviour, IDamageable
    {
        private PlayerStaticData _staticData;

        public int Max { get; private set; }

        public event Action<int> TookDamage;
        public event Action<GameObject> Died;

        public int Current { get; private set; }
        public bool IsDead => Current <= 0;

        private Collider _collider;

        public void Construct(PlayerStaticData staticData)
        {
            _staticData = staticData;
            Max = staticData.Health;

            Current = Max;
            _staticData.StatsUpgraded += OnStatsUpgrade;
        }

        private void Start()
        {
            _collider = GetComponent<Collider>();
        }

        private void OnDestroy()
        {
            _staticData.StatsUpgraded -= OnStatsUpgrade;
        }

        private void OnStatsUpgrade(UpgradeType type)
        {
            if (type != UpgradeType.Health) return;

            Max = _staticData.Health;
            Current = Max;
        }

        public void TakeDamage(int damage)
        {
            Current -= damage;

            TookDamage?.Invoke(damage);

            if (IsDead)
                Die();
        }

        private void Die()
        {
            _collider.enabled = false;
            Died?.Invoke(gameObject);
                
            GetComponentInChildren<Camera>().transform.SetParent(null);
            
            gameObject.SetActive(false);
        }
    }
}