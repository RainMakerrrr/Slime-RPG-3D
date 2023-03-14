using UnityEngine;
using UnityEngine.UI;

namespace Logic.Health
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image _bar;

        private IDamageable _damageable;

        private void Start()
        {
            _damageable = GetComponentInParent<IDamageable>();
            _damageable.TookDamage += OnTookDamage;
        }

        private void OnDestroy()
        {
            _damageable.TookDamage -= OnTookDamage;
        }

        private void OnTookDamage(int damage)
        {
            UpdateValue(_damageable.Current, _damageable.Max);
            
            if (_damageable.Current <= 0)
            {
                gameObject.SetActive(false);    
            }
        }

        private void UpdateValue(int current, int max)
        {
            _bar.fillAmount = (float) current / max;
        }
    }
}