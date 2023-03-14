using Logic.Health;
using UnityEngine;

namespace Logic.Attack
{
    public class MeleeAttack : BaseAttack
    {
        public MeleeAttack(ITransformable transformable, float radius, string layerMask, int damage) : base(transformable, radius,
            layerMask, damage)
        {
        }

        protected override void DealDamage(int damage)
        {
            foreach (Collider collider in Colliders)
            {
                var damageable = collider.GetComponent<IDamageable>();
                damageable?.TakeDamage(damage);
            }
        }
    }
}