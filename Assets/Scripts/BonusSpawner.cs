using System;
using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private float _delay = 20f;
    [SerializeField] private Bonus _bonus;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;

    private bool isSpawning = true;

    private void Start()
    {
        GlobalEvents.OnPlayerHit.AddListener(StopSpawn);
        GlobalEvents.OnStartClicked.AddListener(StartSpawn);
    }

    private void StopSpawn()
    {
        isSpawning = false;
    }

    private void StartSpawn()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(_delay);
            Instantiate(_bonus, _spawnPoint.localPosition, _bonus.transform.rotation, _container);
        }
    }
}
