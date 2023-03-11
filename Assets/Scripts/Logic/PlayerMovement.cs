using System;
using DG.Tweening;
using Logic.Mediator;
using UnityEngine;

namespace Logic
{
    public class PlayerMovement : MonoBehaviour, IMessageReceiver, IMoveable
    {
        [SerializeField] private WayPointHolder _wayPointHolder;

        private ILevelMediator _mediator;

        public Vector3 Position => transform.position;

        public void Construct(ILevelMediator mediator)
        {
            _mediator = mediator;
        }
        
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Vector3? currentWayPoint = _wayPointHolder.GetCurrentWayPoint();
                if (currentWayPoint == null) return;
                
                transform.DOMove(currentWayPoint.Value, 2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    _mediator.Send(this);
                });
            }
        }

        public void Receive()
        {
        }
    }
}