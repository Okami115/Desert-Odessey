using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Variables")]
    [SerializeField] private string id;
    [SerializeField] private int hp;
    [SerializeField] protected int maxHP;
    [SerializeField] private float speed;
    [SerializeField] protected int damegeScale;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform target;

    [Header("Player Config")]
    [SerializeField] protected PlayerConfig playerConfig;

    public string ID { get => id; set => id = value; }
    public int HP { get => hp; set => hp = value; }
    public Transform Player { get => target; set => target = value; }

    private void Start()
    {
        hp = maxHP;
        target = FindAnyObjectByType<PlayerStats>().gameObject.transform;
    }
    void Update()
    {
        if (!playerConfig.isPause) 
        { 
            // Calcular la dirección hacia el jugador
            Vector3 direccion = target.position - transform.position;
            direccion.Normalize();

            rb.AddForce(speed * direccion, ForceMode2D.Force);       
        }
    }

}
