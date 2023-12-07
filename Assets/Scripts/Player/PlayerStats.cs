using GooglePlayGames;
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

    [SerializeField]private float speedBase;
    [SerializeField]private float fireRateBase;
    [SerializeField]private float sizebase;

    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Animator animator;

    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private LevelUpScreen levelUpScreen;

    public int HP { get => hp; set => hp = value; }


    public event Action<int, int> updateHP;
    public event Action<int, int> updateXP;

    public event Action<string> updateMoney;

    public event Action levelUp;
    public event Action dead;

    private void OnEnable()
    {
        EnemySpawner.nextRound += ReciveMoney;
        animator.SetInteger("Skin", playerConfig.CurrentSkin);
        PlayGamesPlatform.Activate();
    }

    private void OnDisable()
    {
        EnemySpawner.nextRound -= ReciveMoney;
        PlayerPrefs.SetInt("Money", playerConfig.Money);
        PlayerPrefs.SetInt("Current Skin", playerConfig.CurrentSkin);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        playerConfig.Speed = 50;
        playerConfig.FireRate = 0.5f;
        playerConfig.Size = 1;

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

        if(hp <= 0)
            dead?.Invoke();
    }

    public void ReciveDamage(int damage)
    {
        hp -= damage;
        updateHP.Invoke(hp, maxHP);
        if(SystemInfo.supportsVibration)
        {
            Handheld.Vibrate();
        }
    }

    public void UpdateHP()
    {
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
        UpdateHP();
    }

    public void SetSize()
    {
        rectTransform.localScale = new Vector2(rectTransform.localScale.x - playerConfig.Size, rectTransform.localScale.y - playerConfig.Size);
    }
}
