using System;
using System.Numerics;

public class SmallEnemy : Enemy, RecyclableObject
{
    private ObjectPool pool;
    public static Action death;
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP = HP - 1;

            if(HP <= 0)
            {
                PlayerStats stats = FindFirstObjectByType<PlayerStats>();
                stats.ReciveXP(maxHP * damegeScale);
                pool.RecycleObject(this.gameObject);
                death?.Invoke();
            }

        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();

            stats.ReciveDamage(HP * damegeScale);
            pool.RecycleObject(this.gameObject);
            death?.Invoke();
        }
    }

    void RecyclableObject.Config(ObjectPool pool)
    {
        this.pool = pool;
    }

    void RecyclableObject.Recycle()
    {
        pool.RecycleObject(this.gameObject);
    }

    void RecyclableObject.Init(UnityEngine.Vector3 pos)
    {
        HP = maxHP;
        transform.position = pos;
    }
}
