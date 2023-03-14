using System;
using System.Collections.Generic;
using StaticData.Player;

namespace Logic.UpgradeSystem
{
    public class StatsUpgrade
    {
        public event Action<UpgradeType> StatsUpgraded;

        public int Health { get; private set; }

        public int Damage { get; private set; }

        public float AttackSpeed { get; private set; }

        private readonly PlayerStaticData _staticData;
        private readonly Dictionary<UpgradeType, int> _levels = new();
        private readonly Dictionary<UpgradeType, int> _costs = new();

        public int GetCostOf(UpgradeType type) => _costs[type];
        public int GetLevelOf(UpgradeType type) => _levels[type];

        public StatsUpgrade(PlayerStaticData staticData)
        {
            _staticData = staticData;
            Health = _staticData.Health;
            Damage = _staticData.Damage;
            AttackSpeed = _staticData.AttackRate;

            InitDictionaries();
        }

        private void InitDictionaries()
        {
            _levels.Add(UpgradeType.Health, 1);
            _levels.Add(UpgradeType.Attack, 1);
            _levels.Add(UpgradeType.AttackSpeed, 1);

            _costs.Add(UpgradeType.Health, 5);
            _costs.Add(UpgradeType.Attack, 6);
            _costs.Add(UpgradeType.AttackSpeed, 7);
        }

        public void Upgrade(UpgradeType type)
        {
            switch (type)
            {
                case UpgradeType.Attack:
                    Damage += 20;
                    _levels[UpgradeType.Attack]++;
                    _costs[UpgradeType.Attack] += 10;
                    _staticData.UpgradeDamage(Damage);
                    break;
                case UpgradeType.Health:
                    Health += 15;
                    _levels[UpgradeType.Health]++;
                    _costs[UpgradeType.Health] += 12;
                    _staticData.UpgradeHealth(Health);
                    break;
                case UpgradeType.AttackSpeed:
                    AttackSpeed += 0.2f;
                    _levels[UpgradeType.AttackSpeed]++;
                    _costs[UpgradeType.AttackSpeed] += 13;
                    _staticData.UpgradeAttackSpeed(AttackSpeed);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            StatsUpgraded?.Invoke(type);
        }
    }
}