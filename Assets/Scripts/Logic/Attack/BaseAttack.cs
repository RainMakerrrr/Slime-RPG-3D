using System.Linq;
using Logic.Health;
using UnityEngine;

namespace Logic.Attack
{
    public abstract class BaseAttack
    {
        private readonly float _radius;
        private readonly string _layerMask;
        private int _damage;

        protected readonly ITransformable Transformable;
        protected readonly Collider[] Colliders = new Collider[1];

        protected BaseAttack(ITransformable transformable, float radius, string layerMask, int damage)
        {
            Transformable = transformable;
            _radius = radius;
            _layerMask = layerMask;
            _damage = damage;
        }

        public void UpdateDamage(int damage)
        {
            _damage = damage;
        }
        
        public void Attack()
        {
            if (Transformable == null || Transformable.IsDestroyed) return;

            int count =
                Physics.OverlapSphereNonAlloc(Transformable.Position, _radius, Colliders,
                    LayerMask.GetMask(_layerMask));

            //Debug.Log(count);

            if (count <= 0) return;

            DealDamage(_damage);
        }

        protected abstract void DealDamage(int damage);
    }
}