using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Logic.UpgradeSystem
{
    public class UpgradeItem : MonoBehaviour
    {
        [SerializeField] private UpgradeType _upgradeType;
        [SerializeField] private Button _button;

        [SerializeField] private TextMeshProUGUI _upgradeLevel;
        [SerializeField] private TextMeshProUGUI _upgradeCost;
        [SerializeField] private TextMeshProUGUI _currentValue;
        public UpgradeType UpgradeType => _upgradeType;

        private string TypeToString()
        {
            switch (_upgradeType)
            {
                case UpgradeType.Attack:
                    return "Attack";
                case UpgradeType.Health:
                    return "Health";
                case UpgradeType.AttackSpeed:
                    return "Attack Speed";
            }

            return string.Empty;
        }

        public void SetUpgradeLevel(int upgradeLevel) => _upgradeLevel.text = $"Lv. {upgradeLevel}";

        public void SetUpgradeCost(int cost) => _upgradeCost.text = $"Enhance \n {cost}";

        public void SetCurrentValue(string currentValue) => _currentValue.text = $"{TypeToString()} \n {currentValue}";

        public void AddListener(UnityAction<UpgradeType> onClickCall) =>
            _button.onClick.AddListener(() => onClickCall(_upgradeType));

        public void RemoveListener(UnityAction<UpgradeType> onClickCall) =>
            _button.onClick.RemoveListener(() => onClickCall(_upgradeType));
    }

    public enum UpgradeType
    {
        Attack,
        Health,
        AttackSpeed
    }
}