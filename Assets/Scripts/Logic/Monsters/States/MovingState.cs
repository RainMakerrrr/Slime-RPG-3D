using UnityEngine;

namespace Logic.Monsters.States
{
    public class MovingState : IState
    {
        private Transform _transform;
        private ITransformable _target;
        private float _moveSpeed;

        public void Enter()
        {
        }

        public void Tick()
        {
            _transform.position =
                Vector3.MoveTowards(_transform.position, _target.Position, _moveSpeed * Time.deltaTime);
        }

        public void Exit()
        {
        }
    }
}