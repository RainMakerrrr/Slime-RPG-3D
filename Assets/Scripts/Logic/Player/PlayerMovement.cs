using System;
using DG.Tweening;
using Logic.Mediator;
using UnityEngine;

namespace Logic.Player
{
    public class PlayerMovement : MonoBehaviour, IMessageReceiver, ITransformable
    {
        [SerializeField] private PlayerAttack _attack;
        [SerializeField] private WayPointHolder _wayPointHolder;
        [SerializeField] private float _moveDuration;

        private ILevelMediator _mediator;
        public Vector3 Position => transform.position;

        public bool IsDestroyed => gameObject.activeInHierarchy == false;

        public void Construct(ILevelMediator mediator, float moveDuration)
        {
            _mediator = mediator;
            _moveDuration = moveDuration;
        }

        private void Start()
        {
            MoveToPoint();
        }

        private void MoveToPoint()
        {
            _attack.enabled = false;

            Waypoint currentWayPoint = _wayPointHolder.GetCurrentWayPoint();
            if (currentWayPoint == null) return;

            transform.DOMove(currentWayPoint.Position, _moveDuration).SetEase(Ease.Linear)
                .OnComplete(() => OnReachWaypoint(currentWayPoint.UnitsCount));
        }

        private void OnReachWaypoint(int unitsCount)
        {
            _attack.enabled = true;
            _mediator.Send(this, unitsCount);
        }

        public void Receive(int count = 0)
        {
            MoveToPoint();
        }
    }
}