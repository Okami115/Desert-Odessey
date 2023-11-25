using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Bullet/Bullets Configuration")]
public class BulletsConfig : ScriptableObject
{
    private Dictionary<string, Bullet> idBullet;
    [SerializeField] private Bullet[] bullets;

    public Bullet GetBulletPrefab(string id)
    {
        if(idBullet == null) { Init(); }

        idBullet.TryGetValue(id, out var newBullet);
        return newBullet;
    }

    private void Init()
    {
        idBullet = new Dictionary<string, Bullet>();

        foreach (var bullet in bullets)
        {
            idBullet.Add(bullet.ID, bullet);
        }
    }
}