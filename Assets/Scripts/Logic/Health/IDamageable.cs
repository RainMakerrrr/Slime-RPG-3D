using System;
using UnityEngine;

namespace Logic.Health
{
    public interface IDamageable
    {
        int Current { get; }
        int Max { get; }
        bool IsDead { get; }

        event Action<int> TookDamage;
        event Action<GameObject> Died;
        void TakeDamage(int damage);
    }
}