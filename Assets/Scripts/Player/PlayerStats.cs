using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private int hp;
    [SerializeField] private int maxHP;

    [SerializeField] private int xp;
    [SerializeField] private int maxXP;

    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private int money;
    public int HP { get => hp; set => hp = value; }


    public event Action<int, int> updateHP;

    private void Start()
    {
        hp = maxHP;
        xp = 0;
        money = playerConfig.Money;
    }

    public void ReciveDamage(int damage)
    {
        hp -= damage;
        updateHP.Invoke(hp, maxHP);
    }
}
