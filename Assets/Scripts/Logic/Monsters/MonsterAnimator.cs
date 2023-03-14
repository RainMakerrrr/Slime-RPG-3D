using UnityEngine;

namespace Logic.Monsters
{
    public class MonsterAnimator : MonoBehaviour
    {
        private static readonly int MoveSpeed = Animator.StringToHash("MoveSpeed");
        private static readonly int Attack = Animator.StringToHash("Attack");
        private static readonly int IsDead = Animator.StringToHash("isDead");
        private static readonly int TakeDamage = Animator.StringToHash("TakeDamage");

        [SerializeField] private Animator _animator;

        public void UpdateMoveSpeed(float moveSpeed) => _animator.SetFloat(MoveSpeed, moveSpeed);

        public void AttackAnimation() => _animator.SetTrigger(Attack);
        public void DieAnimation() => _animator.SetTrigger(IsDead);
        public void TakeDamageAnimation() => _animator.SetTrigger(TakeDamage);
    }
}