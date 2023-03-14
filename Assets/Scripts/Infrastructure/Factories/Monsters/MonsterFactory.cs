using System.Collections.Generic;
using System.Linq;
using Infrastructure.Services.Assets;
using Logic;
using Logic.Health;
using Logic.Monsters;
using StaticData.Monsters;
using UnityEngine;

namespace Infrastructure.Factories.Monsters
{
    public class MonsterFactory : IMonsterFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ITransformable _player;

        private Dictionary<MonsterType, MonsterStaticData[]> _monsters = new();
        private readonly IDamageable _damageable;

        public MonsterFactory(IAssetProvider assetProvider, ITransformable player, IDamageable damageable)
        {
            _assetProvider = assetProvider;
            _player = player;
            _damageable = damageable;
        }


        public void Load()
        {
            MonsterStaticData[] data = _assetProvider.LoadAll<MonsterStaticData>(AssetPath.Monsters);
            _monsters.Add(MonsterType.Medium, data.Where(d => d.MonsterType == MonsterType.Medium).ToArray());
            _monsters.Add(MonsterType.Boss, data.Where(d => d.MonsterType == MonsterType.Boss).ToArray());
        }

        public GameObject Create(MonsterType type)
        {
            MonsterStaticData[] data = _monsters[type];
            GameObject prefab = data[Random.Range(0, data.Length)].MonsterPrefab;
            
            GameObject monsterMovement = Object.Instantiate(prefab);

            return monsterMovement;
        }

        public GameObject Create(MonsterType type, Vector3 position, Transform parent)
        {
            MonsterStaticData[] data = _monsters[type];
            MonsterStaticData staticData = data[Random.Range(0, data.Length)];
            
            GameObject monsterPrefab = staticData.MonsterPrefab;
            GameObject monster =
                Object.Instantiate(monsterPrefab, position, monsterPrefab.transform.rotation, parent);

            monster.GetComponent<MonsterAttack>().Construct(staticData.AttackSpeed, staticData.Damage, _damageable);
            monster.GetComponent<MonsterMovement>().Construct(_player, staticData.MoveSpeed);
            monster.GetComponent<MonsterHealth>().Construct(staticData.Health);

            return monster;
        }
    }
}