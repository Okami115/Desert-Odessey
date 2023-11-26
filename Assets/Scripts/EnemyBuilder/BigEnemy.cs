using Cinemachine.Utility;

public class BigEnemy : Enemy
{
    private void OnTriggerEnter2D(UnityEngine.Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            HP = HP - 1;
        }
    }

    private void OnCollisionEnter2D(UnityEngine.Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats stats = collision.gameObject.GetComponent<PlayerStats>();

            stats.ReciveDamage(HP * damegeScale);

            HP = 0;
        }
    }
}