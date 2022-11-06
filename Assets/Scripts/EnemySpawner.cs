using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int HardLevel { get; set; } = 0;

    [SerializeField] private GameObject topEnemy;
    [SerializeField] private GameObject bottomEnemy;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private Transform container;

    [SerializeField] private float topEnemyMinY = 6f;
    [SerializeField] private float topEnemyMaxY = 1f;
    [SerializeField] private float bottomEnemyMinY = -8f;
    [SerializeField] private float bottomEnemyMaxY = -6f;

    [SerializeField] private float spawnDelay = 2f;

    private System.Random random = new System.Random();

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    public void SetSpawnDelay(float value)
    {
        spawnDelay = Mathf.Clamp(value, 0, int.MaxValue);
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            switch (HardLevel)
            {
                case 1:
                    break;
                default:
                    SpawnTopOrBottomEnemy(spawnPoint.position.x);
                    break;
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    private void SpawnTopOrBottomEnemy(float spawnX)
    {
        int index = random.Next(0, 2);

        switch (index)
        {
            case 0:
                Instantiate(topEnemy, container).transform.localPosition = new Vector2(spawnX, (float)random.NextDouble() * (topEnemyMaxY - topEnemyMinY) + topEnemyMinY);
                break;
            case 1:
                Instantiate(bottomEnemy, container).transform.localPosition = new Vector2(spawnX, (float)random.NextDouble() * (bottomEnemyMaxY - bottomEnemyMinY) + bottomEnemyMinY);
                break;
            default:
                break;
        }
    }
}