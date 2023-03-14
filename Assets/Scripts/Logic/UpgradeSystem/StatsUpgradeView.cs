using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Logic.UpgradeSystem
{
    public class StatsUpgradeView : MonoBehaviour
    {
        public event Action<UpgradeType> ButtonClicked;

        [SerializeField] private UpgradeItem[] _items;

        public void SetUpgradeLevel(int upgradeLevel, UpgradeType upgradeType)
        {
            UpgradeItem item = _items.FirstOrDefault(button => button.UpgradeType == upgradeType);
            if (item != null) item.SetUpgradeLevel(upgradeLevel);
        }

        public void SetUpgradeCost(int upgradeCost, UpgradeType upgradeType)
        {
            UpgradeItem item = _items.FirstOrDefault(button => button.UpgradeType == upgradeType);
            if (item != null) item.SetUpgradeCost(upgradeCost);
        }

        public void SetCurrentValue(string currentValue, UpgradeType upgradeType)
        {
            UpgradeItem item = _items.FirstOrDefault(button => button.UpgradeType == upgradeType);
            if (item != null) item.SetCurrentValue(currentValue);
        }

        private void Start()
        {
            foreach (UpgradeItem button in _items)
            {
                button.AddListener(OnClicked);
            }

        }

        private void OnClicked(UpgradeType upgradeType)
        {
            ButtonClicked?.Invoke(upgradeType);
        }
    }
}