using System;
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

    [Header("Enemies Pool")]
    [SerializeField] private GameObject[] enemies;
    private int currentEnemies;

    private int round;
    public static Action<string> nextRound;

    private void OnEnable()
    {
        SmallEnemy.death += DeadEnemy;
        BigEnemy.death += DeadEnemy;
    }

    private void OnDisable()
    {
        SmallEnemy.death -= DeadEnemy;
        BigEnemy.death -= DeadEnemy;
    }

    private void Start()
    {
        enemyBuilder = new EnemyBuilder(config);
        round = 1;

        for (int i = 0; i < maxEnemyToSpawn; i++)
        {
            SpawnEnemies();
            currentEnemies++;
        }
    }

    private void Update()
    {
        if(currentEnemies <= 0)
        {
            round++;
            nextRound?.Invoke(round.ToString());
            maxEnemyToSpawn += (int)(maxEnemyToSpawn * enemyScaleSpawnPerRound);
            for (int i = 0; i < maxEnemyToSpawn; i++)
            {
                SpawnEnemies();
                currentEnemies++;
            }
        }
    }

    private void SpawnEnemies()
    {
        int randEnemy = UnityEngine.Random.Range(0, IDs.Length);
        int randPos = UnityEngine.Random.Range(0, spawns.Length);

        enemyBuilder.Create(IDs[randEnemy], spawns[randPos].position);    
    }

    private void DeadEnemy()
    {
        currentEnemies--;
    }
}
