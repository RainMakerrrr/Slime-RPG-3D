using Logic.Monsters;
using UnityEngine;

namespace Infrastructure.Factories.Monsters
{
    public interface IMonsterFactory
    {
        void Load();
        GameObject Create(MonsterType type);
        GameObject Create(MonsterType type, Vector3 position, Transform parent);
    }
}