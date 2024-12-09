using System;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class UIManager : MonoBehaviour
{

    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI round;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private TextMeshProUGUI enemies;
    [SerializeField] private RectTransform HP;
    [SerializeField] private RectTransform XP;
    [SerializeField] private PlayerStats player;

    [Header("Configs")]
    [SerializeField] private PlayerConfig playerConfig;

    [Header("Screens")]
    [SerializeField] private GameObject DeadScreen;
    [SerializeField] private GameObject LevelUpScreen;
    [SerializeField] private GameObject PauseScreen;

    private void OnEnable()
    {
        player.updateHP += UpdateHPBar;
        player.updateXP += UpdateXPBar;
        player.updateMoney += UpdateMoneyText;
        player.levelUp += ShowLevelUpScreen;
        player.dead += ShowDeathScreen;
        EnemySpawner.nextRound += UpdateRoundText;
    }

    private void OnDisable()
    {
        player.updateHP -= UpdateHPBar;
        player.updateXP -= UpdateXPBar;
        player.updateMoney -= UpdateMoneyText;
        player.levelUp -= ShowLevelUpScreen;
        player.dead -= ShowDeathScreen;
        EnemySpawner.nextRound -= UpdateRoundText;
    }

    private void Update()
    {
        enemies.text = "X " + playerConfig.currentEnemies.ToString();
    }

    public void UpdateXPBar(int currentXP, int maxXP)
    {
        float aux1 = currentXP;
        float aux2 = maxXP;

        XP.localScale = new Vector3(aux1 / aux2, 1, 1);
    }

    public void UpdateHPBar(int currentHP, int maxHP)
    {
        float aux1 = currentHP;
        float aux2 = maxHP;

        HP.localScale = new Vector3(aux1 / aux2, 1, 1);
    }

    private void UpdateMoneyText(string text)
    {
        money.text = playerConfig.Money.ToString();
    }

    private void UpdateRoundText(string text)
    {
        round.text = text;
    }

    private void ShowLevelUpScreen()
    {
        LevelUpScreen.SetActive(true);
        playerConfig.isPause = !playerConfig.isPause;
        Time.timeScale = 0;
    }

    private void ShowDeathScreen()
    {
        DeadScreen.SetActive(true);
    }

    public void Pause()
    {
        playerConfig.isPause = !playerConfig.isPause;
        PauseScreen.SetActive(playerConfig.isPause);
    }

    public void Resume()
    {
        playerConfig.isPause = false;
        PauseScreen.SetActive(playerConfig.isPause);
    }

    public void LeaderBoard()
    {
        Social.ShowLeaderboardUI();
    }
}
