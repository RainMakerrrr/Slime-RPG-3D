using Infrastructure.Factories.Monsters;
using Infrastructure.Factories.Projectiles;
using Infrastructure.Services.Assets;
using Logic;
using Logic.Health;
using Logic.Mediator;
using Logic.Monsters;
using Logic.Player;
using Logic.SoftCurrency;
using Logic.UpgradeSystem;
using StaticData.Player;
using UnityEngine;

public class GameBootstraper : MonoBehaviour
{
    [SerializeField] private MonsterSpawner _monsterSpawner;
    [SerializeField] private PlayerMovement _player;
    [SerializeField] private CoinsView _coinsView;
    [SerializeField] private StatsUpgradeView _statsUpgradeView;
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private WayPointHolder _wayPointHolder;

    private ILevelMediator _levelMediator;
    private IAssetProvider _assetProvider;
    private IMonsterFactory _monsterFactory;
    private IProjectileFactory _projectileFactory;

    private PlayerStaticData _playerStaticData;

    private CoinsCounter _coinsCounter;
    private CoinsPresenter _coinsPresenter;

    private StatsUpgrade _statsUpgrade;
    private StatsPresenter _statsPresenter;

    private void Start()
    {
        InitAssetProvider();
        InitMonsterFactory();
        InitLevelMediator();
        InitProjectileFactory();
        InitPlayerStaticData();
        InitCoinsCounter();
        InitStatsUpgrade();
        InitPlayer();
        InitMonsterSpawner();
        InitSceneLoader();
    }

    private void OnDestroy()
    {
        _coinsPresenter.Disable();
        _statsPresenter.Disable();
    }


    private void InitAssetProvider() => _assetProvider = new AssetProvider();

    private void InitMonsterFactory() => _monsterFactory = new MonsterFactory(_assetProvider, _player, _player.GetComponent<IDamageable>());

    private void InitProjectileFactory() => _projectileFactory = new ProjectileFactory(_assetProvider);

    private void InitMonsterSpawner()
    {
        _monsterSpawner.Construct(_levelMediator, _monsterFactory, _player, _coinsCounter);
        _monsterSpawner.gameObject.SetActive(true);
    }


    private void InitLevelMediator() => _levelMediator = new LevelMediator(_player, _monsterSpawner);

    private void InitPlayer()
    {
        _player.Construct(_levelMediator, _playerStaticData.MoveDuration);
        _player.GetComponent<PlayerAttack>().Construct(_playerStaticData, _projectileFactory);
        _player.GetComponent<PlayerHealth>().Construct(_playerStaticData);
    }

    private void InitPlayerStaticData() =>
        _playerStaticData = _assetProvider.Load<PlayerStaticData>(AssetPath.PlayerStaticData);

    private void InitCoinsCounter()
    {
        _coinsCounter = new CoinsCounter();
        _coinsPresenter = new CoinsPresenter(_coinsCounter, _coinsView);
        _coinsPresenter.Enable();
    }

    private void InitStatsUpgrade()
    {
        _statsUpgrade = new StatsUpgrade(_playerStaticData);
        _statsPresenter = new StatsPresenter(_statsUpgrade, _statsUpgradeView, _coinsCounter);
        _statsPresenter.Enable();
    }

    private void InitSceneLoader() => _sceneLoader.Construct(_player.GetComponent<IDamageable>(), _wayPointHolder);
}