using UnityEngine;

public class EnemyBuilder
{
    private readonly EnemyConfig config;

    public EnemyBuilder(EnemyConfig config)
    {
        this.config = config;
    }

    public Enemy Create(Transform player, string id, Vector3 spawnPosition)
    {
        var enemy = config.GetBulletPrefab(id);

        enemy.Player = player;

        return Object.Instantiate(enemy, spawnPosition, Quaternion.identity);
    }
}