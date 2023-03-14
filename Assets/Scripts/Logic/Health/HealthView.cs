using DG.Tweening;
using TMPro;
using UnityEngine;

namespace Logic.Health
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _damageText;

        private IDamageable _damageable;
        private ITransformable _transformable;
        private Color _startColor;
        private Tween _moveTween;
        private Tween _fadeTween;

        private void Start()
        {
            _startColor = _damageText.color;
            _damageText.gameObject.SetActive(false);

            _damageable = GetComponentInParent<IDamageable>();
            _transformable = GetComponentInParent<ITransformable>();
            _damageable.TookDamage += OnTookDamage;
        }

        private void OnDestroy()
        {
            _damageable.TookDamage -= OnTookDamage;
        }

        private void OnTookDamage(int damage)
        {
            _moveTween?.Kill();
            _fadeTween?.Kill();

            _damageText.gameObject.SetActive(true);
            _damageText.transform.position = _transformable.Position + Vector3.up * 1.5f;
            _damageText.text = damage.ToString();
            _damageText.color = _startColor;
            _moveTween = _damageText.transform.DOMoveY(_damageText.transform.position.y + 3f, 1.5f)
                .SetEase(Ease.Linear);
            _fadeTween = _damageText.DOFade(0f, 1.5f);
        }
    }
}