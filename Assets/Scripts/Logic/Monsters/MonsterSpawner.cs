using System;
using System.Collections;
using System.Collections.Generic;
using Infrastructure.Factories.Monsters;
using Logic.Health;
using Logic.Mediator;
using Logic.SoftCurrency;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.Monsters
{
    public class MonsterSpawner : MonoBehaviour, IMessageReceiver
    {
        [SerializeField] private MonsterType[] _types;
        
        private ILevelMediator _mediator;
        private IMonsterFactory _factory;
        private ITransformable _target;

        private readonly List<GameObject> _monsters = new();
        private CoinsCounter _coinsCounter;

        public void Construct(ILevelMediator mediator, IMonsterFactory factory, ITransformable target,
            CoinsCounter coinsCounter)
        {
            _mediator = mediator;
            _factory = factory;
            _target = target;
            _coinsCounter = coinsCounter;
            _factory.Load();
        }

        public void Receive(int count = 0)
        {
            Spawn(count);
        }

        private void Spawn(int count)
        {
            for (int i = 0; i < count; i++)
            {
                Vector3 spawnPosition =
                    _target.Position + new Vector3(Random.Range(9f, 12f), Random.Range(-1f, 1f), 0f);

                GameObject monsterMovement =
                    _factory.Create(_types[Random.Range(0, _types.Length)], spawnPosition, transform);
                monsterMovement.GetComponent<IDamageable>().Died += OnMonsterDied;
                _monsters.Add(monsterMovement);
            }
        }

        private void OnMonsterDied(GameObject monster)
        {
            _monsters.Remove(monster);
            _coinsCounter.Add(Random.Range(10, 40));

            if (_monsters.Count == 0)
            {
                _mediator.Send(this);
            }
        }
    }
}