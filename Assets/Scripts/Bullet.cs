using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Vector2 trayectory;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private void Update()
    {
        rb.AddForce(speed * trayectory.normalized, ForceMode2D.Force);
        Destroy(gameObject, 2);
    }

    public void SetTrajectory(Vector3 trayectory)
    {
        this.trayectory = trayectory;
    }
}
