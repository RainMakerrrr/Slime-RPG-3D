using Logic.Mediator;
using UnityEngine;

namespace Logic
{
    public class WayPointHolder : MonoBehaviour
    {
        [SerializeField] private Transform[] _points;

        private ILevelMediator _mediator;

        private int _index;

        private bool OutOfPoints => _index >= _points.Length;


        public Vector3? GetCurrentWayPoint()
        {
            if (OutOfPoints) return null;

            Vector3 point = _points[_index].position;
            _index++;

            return point;
        }
    }
}