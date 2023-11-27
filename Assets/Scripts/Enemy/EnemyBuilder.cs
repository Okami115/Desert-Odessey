using System.Collections.Generic;
using UnityEngine;

public class EnemyBuilder
{
    private readonly EnemyConfig config;
    private Dictionary<string, ObjectPool> pools;

    public EnemyBuilder(EnemyConfig config)
    {
        pools = new Dictionary<string, ObjectPool>(); 

        this.config = config;

        for (int i = 0; i < config.Enemies.Length; i++)
        {
            var pool = new ObjectPool(config.Enemies[i].gameObject);
            pool.Init(10);
            pools.Add(config.Enemies[i].ID, pool);
        }
    }

    public void Create(string id, Vector3 spawnPosition)
    {
        var enemy = pools[id];

        enemy.Spawn(spawnPosition);
    }
}