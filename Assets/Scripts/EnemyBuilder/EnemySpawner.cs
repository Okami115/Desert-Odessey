using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Spawner Variable")]
    [SerializeField] private int maxEnemyToSpawn;
    [SerializeField] private Transform[] spawns;
    [SerializeField] private EnemyConfig config;
    [SerializeField] private Transform player;
    private EnemyBuilder enemyBuilder;

    [Header("Enemies Variable")]
    [SerializeField] private float enemyScaleSpawnPerRound;
    [SerializeField] private string[] IDs;

    private int enemyCounter;

    // Start is called before the first frame update
    void Start()
    {
        enemyBuilder = new EnemyBuilder(config);

        for (int i = 0; i < maxEnemyToSpawn; i++)
        {
            SpawnEnemies();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void SpawnEnemies()
    {
        int randEnemy = Random.Range(0, IDs.Length);
        int randPos = Random.Range(0, spawns.Length);

        enemyBuilder.Create(player, IDs[randEnemy], spawns[randPos].position);
    }
}
