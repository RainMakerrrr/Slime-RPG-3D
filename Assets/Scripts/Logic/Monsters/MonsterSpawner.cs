using System;
using System.Collections.Generic;
using Infrastructure.Factories.Monsters;
using Logic.Mediator;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic.Monsters
{
    public class MonsterSpawner : MonoBehaviour, IMessageReceiver
    {
        private ILevelMediator _mediator;
        private IMonsterFactory _factory;
        private IMoveable _target;

        private List<Monster> _monsters = new List<Monster>();

        public void Construct(ILevelMediator mediator, IMonsterFactory factory, IMoveable target)
        {
            _mediator = mediator;
            _factory = factory;
            _target = target;
        }

        private void Start()
        {
            _factory.Load();
        }


        public void Receive()
        {
            Spawn();
        }

        private void Spawn()
        {
            Vector3 spawnPosition = _target.Position + new Vector3(Random.Range(4f, 7f), Random.Range(0f, 3f), 0f);

            Monster monster = _factory.Create(MonsterType.Medium, spawnPosition, transform);
            
        }
    }
}