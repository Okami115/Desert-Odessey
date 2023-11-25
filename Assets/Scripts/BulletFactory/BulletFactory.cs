using UnityEngine;

public class BulletFactory
{
    private readonly BulletsConfig config;

    public BulletFactory(BulletsConfig config)
    {
        this.config = config;
    }

    public Bullet Create(Vector2 Trayectory, string id)
    {
        var bullet = config.GetBulletPrefab(id);

        bullet.Trayectory = Trayectory;

        return Object.Instantiate(bullet);
    }
}
