using Infrastructure.Services;
using Infrastructure.Services.Assets;
using Logic;
using UnityEngine;

namespace Infrastructure.Factories.Projectiles
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IAssetProvider _assetProvider;
        private Projectile _projectilePrefab;

        public ProjectileFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public Projectile Create()
        {
            _projectilePrefab ??= _assetProvider.Load<Projectile>(AssetPath.ProjectilePrefab);
            Projectile projectile = Object.Instantiate(_projectilePrefab);

            return projectile;
        }

        public Projectile Create(Vector3 position, Transform parent)
        {
            _projectilePrefab ??= _assetProvider.Load<Projectile>(AssetPath.ProjectilePrefab);
            Projectile projectile =
                Object.Instantiate(_projectilePrefab, position, _projectilePrefab.transform.rotation, parent);

            return projectile;
        }
    }
}