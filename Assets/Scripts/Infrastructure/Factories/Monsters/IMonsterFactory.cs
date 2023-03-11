using Logic.Monsters;
using UnityEngine;

namespace Infrastructure.Factories.Monsters
{
    public interface IMonsterFactory
    {
        void Load();
        Monster Create(MonsterType type);
        Monster Create(MonsterType type, Vector3 position, Transform parent);
    }
}