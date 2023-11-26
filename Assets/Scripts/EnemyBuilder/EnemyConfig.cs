using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemies Configuration")]
public class EnemyConfig : ScriptableObject
{
    private Dictionary<string, Enemy> idEnemy;
    [SerializeField] private Enemy[] enemies;

    public Enemy GetBulletPrefab(string id)
    {
        if (idEnemy == null) { Init(); }

        idEnemy.TryGetValue(id, out var newEnemy);
        return newEnemy;
    }

    private void Init()
    {
        idEnemy = new Dictionary<string, Enemy>();

        foreach (var Enemy in enemies)
        {
            idEnemy.Add(Enemy.ID, Enemy);
        }
    }
}
