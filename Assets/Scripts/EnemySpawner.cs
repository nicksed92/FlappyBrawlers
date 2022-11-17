using System.Collections;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private float _spawnDelay = 3f;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Enemy _bottomEnemy;
    [SerializeField] private Enemy _topEnemy;

    private bool isSpawning = true;

    void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isSpawning)
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

            yield return new WaitForSeconds(_spawnDelay);
        }
    }

    private void SpawnEnemy(Enemy prefab)
    {
        Instantiate(prefab, _spawnPoint.position, prefab.transform.rotation, _container);
    }
}