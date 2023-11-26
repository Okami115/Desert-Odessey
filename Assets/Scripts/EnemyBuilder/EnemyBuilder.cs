using UnityEngine;

public class EnemyBuilder
{
    private readonly EnemyConfig config;

    public EnemyBuilder(EnemyConfig config)
    {
        this.config = config;
    }

    public Enemy Create(Vector2 Trayectory, string id)
    {
        var enemy = config.GetBulletPrefab(id);

        return Object.Instantiate(enemy);
    }
}