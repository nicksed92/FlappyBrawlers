using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    private enum GameHard
    {
        Easy,
        Normal,
        Hard,
        VeryHard
    }

    [SerializeField] private float _defaultSpawnDelay;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _bottomEnemy;
    [SerializeField] private Enemy _topEnemy;
    [SerializeField] private Enemy _doubleEnemy;

    private float _spawnDelay;
    private bool isSpawning = true;
    private Player _player;

    private void Awake()
    {
        GlobalEvents.OnPlayerHit.AddListener(StopSpawn);
        GlobalEvents.OnStartClicked.AddListener(StartSpawn);
    }

    private void Start()
    {
        _player = FindObjectOfType<Player>();
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isSpawning)
        {
            _spawnDelay = _defaultSpawnDelay;

            switch (GetGameHard())
            {
                case GameHard.Easy:
                    EasySpawn();
                    break;
                case GameHard.Normal:
                    NormalSpawn();
                    _spawnDelay *= 0.8f;
                    break;
                case GameHard.Hard:
                    _spawnDelay *= 0.4f;
                    HardSpawn();
                    break;
                case GameHard.VeryHard:
                    _spawnDelay *= 0.25f;
                    HardSpawn();
                    break;
                default:
                    break;
            }

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void SpawnEnemy(Enemy prefab)
    {
        Enemy enemy = Instantiate(prefab, _spawnPoint.position, prefab.transform.rotation, _container);

        switch (GetGameHard())
        {
            case GameHard.Easy:
                break;
            case GameHard.Normal:
                enemy.MoveSpeed += 1f;
                break;
            case GameHard.Hard:
            case GameHard.VeryHard:
                enemy.MoveSpeed += 1.5f;
                break;
            default:
                break;
        }
    }

    private void StopSpawn()
    {
        isSpawning = false;
    }

    private GameHard GetGameHard()
    {
        GameHard gameHard = new GameHard();
        int score = _player.Score;

        if (score < 100)
            gameHard = GameHard.Easy;
        else
            if (score >= 100 && score < 500)
            gameHard = GameHard.Normal;
        else
            if (score >= 500 && score < 1000)
            gameHard = GameHard.Hard;
        else
            if (score >= 1000)
            gameHard = GameHard.VeryHard;

        return gameHard;
    }

    private void EasySpawn()
    {
        switch (Utilites.GetRandomInt(0, 1))
        {
            case 1:
                SpawnEnemy(_topEnemy);
                break;
            default:
                SpawnEnemy(_bottomEnemy);
                break;
        }
    }

    private void NormalSpawn()
    {
        switch (Utilites.GetRandomInt(0, 2))
        {
            case 1:
                SpawnEnemy(_topEnemy);
                break;
            case 2:
                SpawnEnemy(_doubleEnemy);
                break;
            default:
                SpawnEnemy(_bottomEnemy);
                break;
        }
    }

    private void HardSpawn()
    {
        SpawnEnemy(_doubleEnemy);
    }
}