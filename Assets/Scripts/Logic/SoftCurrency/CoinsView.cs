using TMPro;
using UnityEngine;

namespace Logic.SoftCurrency
{
    public class CoinsView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _coinsText;
        [SerializeField] private Transform _coinPrefab;
        [SerializeField] private Transform _coinIcon;
        
        public void AnimateCoins()
        {
            Transform coin = Instantiate(_coinPrefab);
        }
        
        public void UpdateText(string value)
        {
            _coinsText.text = value;
        }
    }
}