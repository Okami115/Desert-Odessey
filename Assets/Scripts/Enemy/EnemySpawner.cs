using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Variable")]
    [SerializeField] private int maxEnemyToSpawn;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private EnemyConfig config;
    private EnemyBuilder enemyBuilder;

    [Header("Enemies Variable")]
    [SerializeField] private float enemyScaleSpawnPerRound;
    [SerializeField] private string[] IDs;

    private int enemyCounter;
    [Header("Enemies Pool")]
    [SerializeField] private GameObject[] enemies;
    [SerializeField] private int TotalAmountToSpawn;

    void Start()
    {
        enemyBuilder = new EnemyBuilder(config);

        for (int i = 0; i < maxEnemyToSpawn; i++)
        {
            SpawnEnemies();
        }
    }

    private void SpawnEnemies()
    {
        int randEnemy = Random.Range(0, IDs.Length);
        int randPos = Random.Range(0, spawns.Length);

        enemyBuilder.Create(IDs[randEnemy], spawns[randPos].position);    }
}
