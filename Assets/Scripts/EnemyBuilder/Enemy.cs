using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private int hp;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;

    public string ID { get => id; set => id = value; }
    public int HP { get => hp; set => hp = value; }

    void Update()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direccion = player.position - transform.position;
        direccion.Normalize();


        rb.AddForce(speed * direccion, ForceMode2D.Force);
    }

}
