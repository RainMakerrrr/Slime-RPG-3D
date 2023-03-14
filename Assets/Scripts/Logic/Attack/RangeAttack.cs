using Infrastructure.Factories.Projectiles;
using UnityEngine;

namespace Logic.Attack
{
    public class RangeAttack : BaseAttack
    {
        private readonly IProjectileFactory _projectileFactory;
        
        public RangeAttack(ITransformable transformable, float radius, string layerMask, int damage,
            IProjectileFactory projectileFactory) : base(transformable, radius, layerMask, damage)
        {
            _projectileFactory = projectileFactory;
        }
        
        protected override void DealDamage(int damage)
        {
            foreach (Collider collider in Colliders)
            {
                var moveable = collider.GetComponent<ITransformable>();
                if (moveable == null) return;
                
                Vector3 direction = (moveable.Position - Transformable.Position).normalized;
                direction.y += 0.25f;
                
                Projectile projectile = _projectileFactory.Create();
                projectile.SetDamage(damage);
                projectile.transform.position = Transformable.Position;
                projectile.Shoot(direction);
            }
        }
    }
}