using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Button[] buttons;

    public float speedScale;
    public float fireRateScale;
    public float sizeScale;

    public event Action restoreHP;

   public void OnEnable()
    {
        if (playerConfig.Speed >= playerConfig.SpeedLimit)
        {
            buttons[0].interactable = false;
        }
        if (playerConfig.FireRate <= playerConfig.FireRateLimit)
        {
            buttons[1].interactable = false;
        }
        if (playerConfig.Size <= playerConfig.SizeLimit)
        {
            buttons[2].interactable = false;
        }
   }

    public void OnDisable()
    {
        playerConfig.isPause = !playerConfig.isPause;
        Time.timeScale = 1f;
    }

    private void Start()
    {
        speedScale = (playerConfig.SpeedLimit - playerConfig.Speed) / playerConfig.MaxUpgrades;
        fireRateScale = (playerConfig.FireRate - playerConfig.FireRateLimit) / playerConfig.MaxUpgrades;
        sizeScale = (playerConfig.SizeLimit - playerConfig.Size) / playerConfig.MaxUpgrades;
    }

    public void MoreSpeed()
    {
        playerConfig.Speed = playerConfig.Speed + speedScale;
        gameObject.SetActive(false);
    }

    public void MoreFireRate()
    {
        playerConfig.FireRate = playerConfig.FireRate - fireRateScale;
        gameObject.SetActive(false);
    }

    public void ReduceSize()
    {
        playerConfig.Size = playerConfig.Size * 0.80f;
        stats.SetSize();
        gameObject.SetActive(false);
    }

    public void MaxHP()
    {
        stats.SetMaxHP();
        gameObject.SetActive(false);
        restoreHP?.Invoke();
    }
}
