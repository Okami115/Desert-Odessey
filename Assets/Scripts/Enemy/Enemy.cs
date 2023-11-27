using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private string id;
    [SerializeField] private int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] private float speed;
    [SerializeField] protected int damegeScale;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform player;

    public string ID { get => id; set => id = value; }
    public int HP { get => hp; set => hp = value; }
    public Transform Player { get => player; set => player = value; }

    private void Start()
    {
        hp = maxHP;
        player = FindAnyObjectByType<PlayerStats>().gameObject.transform;
    }
    void Update()
    {
        // Calcular la dirección hacia el jugador
        Vector3 direccion = player.position - transform.position;
        direccion.Normalize();

        rb.AddForce(speed * direccion, ForceMode2D.Force);
    }

}
