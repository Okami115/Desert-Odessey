using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UI;

public class LevelUpScreen : MonoBehaviour
{
    [SerializeField] private float upgradeScale;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private PlayerStats stats;
    [SerializeField] private Button[] buttons; 

    void Start()
    {
        Time.timeScale = 0;
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

    public void MoreSpeed()
    {
        playerConfig.Speed += playerConfig.Speed * upgradeScale;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MoreFireRate()
    {
        playerConfig.FireRate -= playerConfig.FireRate * upgradeScale;
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void ReduceSize()
    {
        playerConfig.Size += upgradeScale;
        stats.SetSize();
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

    public void MaxHP()
    {
        stats.SetMaxHP();
    }
}
