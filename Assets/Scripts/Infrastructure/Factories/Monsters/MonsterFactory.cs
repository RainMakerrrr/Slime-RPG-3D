using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services;
using Logic.Monsters;
using UnityEngine;

namespace Infrastructure.Factories.Monsters
{
    public class MonsterFactory : IMonsterFactory
    {
        private readonly IAssetProvider _assetProvider;

        private Dictionary<MonsterType, Monster> _monsters;

        public MonsterFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public void Load()
        {
            _monsters = _assetProvider.LoadAll<Monster>(AssetPath.Monsters).ToDictionary(m => m.Type);
        }

        public Monster Create(MonsterType type)
        {
            Monster monster = Object.Instantiate(_monsters[type]);

            return monster;
        }

        public Monster Create(MonsterType type, Vector3 position, Transform parent)
        {
            Monster monster = Object.Instantiate(_monsters[type], position, Quaternion.identity, parent);

            return monster;
        }
    }
}