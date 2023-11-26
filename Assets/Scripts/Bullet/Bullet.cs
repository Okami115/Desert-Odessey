using System;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private string id;

    public Vector2 trayectory;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    public string ID { get => id; set => id = value; }
    public Vector2 Trayectory { get => trayectory; set => trayectory = value; }

    private void Update()
    {
        rb.AddForce(speed * trayectory.normalized, ForceMode2D.Force);
        Destroy(gameObject, 2);
    }


}
