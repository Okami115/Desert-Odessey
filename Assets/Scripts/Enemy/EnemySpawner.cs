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

    [Header("Player Config")]
    [SerializeField] private PlayerConfig playerConfig;

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
        playerConfig.currentEnemies = 0;
        enemyBuilder = new EnemyBuilder(config);
        round = 1;

        for (int i = 0; i < maxEnemyToSpawn; i++)
        {
            SpawnEnemies();
        }
    }

    private void Update()
    {
        if(playerConfig.currentEnemies <= 0)
        {
            round++;
            Social.ReportScore(round, GPGSIds.leaderboard_max_wave, LeaderboardUpdate);
            nextRound?.Invoke(round.ToString());
            maxEnemyToSpawn += (int)(maxEnemyToSpawn * enemyScaleSpawnPerRound);
            for (int i = 0; i < maxEnemyToSpawn; i++)
            {
                SpawnEnemies();
            }
        }
    }

    private void SpawnEnemies()
    {
        int randEnemy = UnityEngine.Random.Range(0, IDs.Length);
        int randPos = UnityEngine.Random.Range(0, spawns.Length);

        enemyBuilder.Create(IDs[randEnemy], spawns[randPos].position);
        playerConfig.currentEnemies++;
    }

    private void DeadEnemy()
    {
        playerConfig.currentEnemies--;
    }

    private void LeaderboardUpdate(bool success)
    {
        if (success)
            Debug.Log("Update Leaderboard");
        else
            Debug.LogError("No Leaderboard");
    }
}
