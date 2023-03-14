using System;
using Logic.Mediator;
using UnityEngine;

namespace Logic
{
    public class WayPointHolder : MonoBehaviour
    {
        public event Action ReachAllPoints;
        
        [SerializeField] private Waypoint[] _points;

        private ILevelMediator _mediator;

        private int _index;

        private bool OutOfPoints => _index >= _points.Length;


        public Waypoint GetCurrentWayPoint()
        {
            if (OutOfPoints)
            {
                ReachAllPoints?.Invoke();
                return null;
            }

            Waypoint point = _points[_index];
            _index++;

            return point;
        }
    }
}