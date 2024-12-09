using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerStats;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private GameObject DeadScreen;
    [SerializeField] private UIManager UIManager;

    private void Start()
    {
        playerStats.dead += PauseGame;
    }

    private void OnDestroy()
    {
        playerStats.dead -= PauseGame;
    }

    private void PauseGame()
    {
        StartCoroutine(StartAdsDeath());
        playerConfig.isPause = true;
    }
    
    public void reviveStart()
    {
        AdsManager.instance.completedAdsReward += reviveComplete;
        AdsManager.instance.ShowAds();
    }
    public void reviveComplete()
    {
        playerConfig.isPause = false;
        playerStats.isDead = false;
        playerStats.HP = playerStats.maxHP;
        DeadScreen.SetActive(false);
        UIManager.UpdateHPBar(playerStats.HP, playerStats.maxHP);
        AdsManager.instance.completedAdsReward -= reviveComplete;
    }

    IEnumerator StartAdsDeath()
    {
        yield return new WaitForSeconds(0.5f);
        AdsManager.instance.ShowAds();
    }

}
