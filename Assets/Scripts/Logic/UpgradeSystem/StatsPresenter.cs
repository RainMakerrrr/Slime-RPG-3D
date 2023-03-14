using System;
using System.Globalization;
using Logic.SoftCurrency;
using UnityEngine;

namespace Logic.UpgradeSystem
{
    public class StatsPresenter
    {
        private readonly StatsUpgrade _model;
        private readonly StatsUpgradeView _view;
        private readonly CoinsCounter _coins;

        public StatsPresenter(StatsUpgrade model, StatsUpgradeView view, CoinsCounter coins)
        {
            _model = model;
            _view = view;
            _coins = coins;
        }

        public void Enable()
        {
            _view.ButtonClicked += OnButtonClicked;
            _model.StatsUpgraded += OnStatsUpgraded;

            OnStatsUpgraded(UpgradeType.Attack);
            OnStatsUpgraded(UpgradeType.Health);
            OnStatsUpgraded(UpgradeType.AttackSpeed);
        }

        public void Disable()
        {
            _view.ButtonClicked -= OnButtonClicked;
            _model.StatsUpgraded -= OnStatsUpgraded;
        }

        private void OnStatsUpgraded(UpgradeType upgradeType)
        {
            switch (upgradeType)
            {
                case UpgradeType.Attack:
                    _view.SetCurrentValue(_model.Damage.ToString(), upgradeType);
                    break;
                case UpgradeType.Health:
                    _view.SetCurrentValue(_model.Health.ToString(), upgradeType);
                    break;
                case UpgradeType.AttackSpeed:
                    _view.SetCurrentValue(_model.AttackSpeed.ToString(CultureInfo.InvariantCulture), upgradeType);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(upgradeType), upgradeType, null);
            }

            _view.SetUpgradeLevel(_model.GetLevelOf(upgradeType), upgradeType);
            _view.SetUpgradeCost(_model.GetCostOf(upgradeType), upgradeType);
        }

        private void OnButtonClicked(UpgradeType upgradeType)
        {
            int cost = _model.GetCostOf(upgradeType);
            
            if (_coins.Current < cost)
            {
                Debug.Log("No currency for upgrade");
                return;
            }
            
            _coins.Remove(cost);
            _model.Upgrade(upgradeType);
        }
    }
}