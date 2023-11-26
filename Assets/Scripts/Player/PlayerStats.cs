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
    public event Action<int, int> updateXP;

    public event Action<string> updateMoney;

    public event Action levelUp;

    private void Start()
    {
        hp = maxHP;
        xp = 0;
        money = playerConfig.Money;
        updateXP.Invoke(xp, maxXP);
        updateHP.Invoke(hp, maxHP);
        updateMoney?.Invoke(money.ToString());
    }

    private void Update()
    {
        if(xp >= maxXP)
        {
            xp = 0;
            levelUp?.Invoke();
            maxXP = (int)(maxXP * 1.5f);
            updateXP.Invoke(xp, maxXP);
        }
    }

    public void ReciveDamage(int damage)
    {
        hp -= damage;
        updateHP.Invoke(hp, maxHP);
    }

    public void ReciveXP(int XP)
    {
        xp += XP;
        updateXP.Invoke(xp, maxXP);
    }

    public void ReciveMoney(int money)
    {
        this.money += money;
        updateMoney?.Invoke(money.ToString());
    }
}
