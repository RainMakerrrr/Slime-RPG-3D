using Logic;
using UnityEngine;

namespace Infrastructure.Factories.Projectiles
{
    public interface IProjectileFactory
    {
        Projectile Create();
        Projectile Create(Vector3 position, Transform parent);
    }
}