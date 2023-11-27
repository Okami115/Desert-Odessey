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

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Animator animator;

    [SerializeField] private PlayerConfig playerConfig;
    public int HP { get => hp; set => hp = value; }


    public event Action<int, int> updateHP;
    public event Action<int, int> updateXP;

    public event Action<string> updateMoney;

    public event Action levelUp;

    private void OnEnable()
    {
        EnemySpawner.nextRound += ReciveMoney;
        playerConfig.Money = PlayerPrefs.GetInt("Money", 0);
        animator.SetInteger("Skin", PlayerPrefs.GetInt("Skin", 0));
    }

    private void OnDisable()
    {
        EnemySpawner.nextRound -= ReciveMoney;
        PlayerPrefs.SetInt("Money", playerConfig.Money);
    }

    private void Start()
    {
        hp = maxHP;
        xp = 0;
        playerConfig.Money = playerConfig.Money;
        updateXP.Invoke(xp, maxXP);
        updateHP.Invoke(hp, maxHP);
        updateMoney?.Invoke(playerConfig.Money.ToString());
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

    public void ReciveMoney(string money)
    {
        playerConfig.Money++;
        updateMoney?.Invoke(money.ToString());
    }

    public void SetMaxHP()
    {
        hp = maxHP;
    }

    public void SetSize()
    {
        rectTransform.localScale = new Vector2(rectTransform.localScale.x - playerConfig.Size, rectTransform.localScale.y - playerConfig.Size);
    }
}
