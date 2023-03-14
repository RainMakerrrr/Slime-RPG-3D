using Logic.Health;
using UnityEngine;

namespace Logic.Monsters
{
    public class MonsterMovement : MonoBehaviour, ITransformable
    {
        [SerializeField] private Rigidbody _rigidbody;
        [SerializeField] private MonsterAnimator _animator;
        [SerializeField] private MonsterAttack _attack;
        [SerializeField] private MonsterHealth _health;

        private ITransformable _target;
        private float _moveSpeed;
        public Vector3 Position => transform.position;
        public bool IsDestroyed => gameObject.activeSelf == false;

        public void Construct(ITransformable target, float moveSpeed)
        {
            _target = target;
            _moveSpeed = moveSpeed;
        }
        

        private void Start()
        {
            _attack.enabled = false;
            _health.Died += OnDied;
        }

        private void OnDestroy()
        {
            _health.Died -= OnDied;
        }

        private void OnDied(GameObject monster)
        {
            _rigidbody.velocity = Vector3.zero;
            enabled = false;
        }

        private void Update()
        {
            _animator.UpdateMoveSpeed(_rigidbody.velocity.magnitude);

            if (_target == null || _target.IsDestroyed)
            {
                _rigidbody.velocity = Vector3.zero;
                return;
            }
            
            if (Vector3.Distance(transform.position, _target.Position) >= 1.5f)
            {
                Vector3 direction = (_target.Position - transform.position).normalized;
                _rigidbody.velocity = direction * _moveSpeed;
                
            }
            else
            {
                _rigidbody.velocity = Vector3.zero;
                _attack.enabled = true;
            }
        }
    }
}