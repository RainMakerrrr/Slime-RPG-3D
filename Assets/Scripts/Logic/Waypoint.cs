using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Logic
{
    public class Waypoint : MonoBehaviour
    {
        [SerializeField] private int _min;
        [SerializeField] private int _max;
        
        public int UnitsCount { get; private set; }

        public Vector3 Position => transform.position;

        private void Start()
        {
            UnitsCount = Random.Range(_min, _max);
        }
    }
}