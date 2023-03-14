using Infrastructure.Factories.Projectiles;
using Logic.Attack;
using Logic.UpgradeSystem;
using StaticData.Player;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        private const string EnemyLayerMask = "Enemy";

        private PlayerStaticData _staticData;

        private BaseAttack _baseAttack;
        private IProjectileFactory _projectileFactory;
        private float _attackRate;
        private int _damage;
        private float _nextShootTime;
        private float _radius;
        
        public void Construct(PlayerStaticData staticData, IProjectileFactory projectileFactory)
        {
            _staticData = staticData;
            _damage = staticData.Damage;
            _attackRate = staticData.AttackRate;
            _radius = staticData.Radius;
            _projectileFactory = projectileFactory;
            
            _baseAttack = new RangeAttack(GetComponent<ITransformable>(), _radius, EnemyLayerMask, _damage,
                _projectileFactory);
            
            _staticData.StatsUpgraded += OnStatsUpgraded;

        }

        private void OnStatsUpgraded(UpgradeType type)
        {
            if (type == UpgradeType.Attack)
            {
                _damage = _staticData.Damage;
                _baseAttack.UpdateDamage(_damage);
            }
            else if (type == UpgradeType.AttackSpeed)
            {
                _attackRate = _staticData.AttackRate;
            }
        }

        private void Update()
        {
            Attack();
        }

        private void Attack()
        {
            if (!(Time.time > _nextShootTime)) return;

            _baseAttack.Attack();

            _nextShootTime = Time.time + 1 / _attackRate;
        }
    }
}