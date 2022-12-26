using System;
using System.Collections;
using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private float _delay = 20f;
    [SerializeField] private Bonus _bonus;
    [SerializeField] private Transform _container;
    [SerializeField] private Transform _spawnPoint;

    private Bonus _currentBonus;

    public void StopSpawn()
    {
        CancelInvoke(nameof(Spawn));

        if (_currentBonus != null)
            Destroy(_currentBonus.gameObject);
    }

    private void Start()
    {
        GlobalEvents.OnPlayerHit.AddListener(StopSpawn);
        GlobalEvents.OnStartClicked.AddListener(StartSpawn);
    }

    private void StartSpawn()
    {
        InvokeRepeating(nameof(Spawn), _delay, _delay);
    }

    private void Spawn()
    {
        _currentBonus = Instantiate(_bonus, _spawnPoint.localPosition, _bonus.transform.rotation, _container);
    }
}