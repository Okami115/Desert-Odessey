using TMPro;
using UnityEngine;

public class AddCoins : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private TextMeshProUGUI Money;

    public void addCoinStart()
    {
        AdsManager.instance.completedAdsReward += addCoinComplete;
        AdsManager.instance.ShowAds();
    }
    public void addCoinComplete()
    {
        playerConfig.Money += 5 ;
        PlayerPrefs.SetInt("Money", playerConfig.Money);
        Money.text = playerConfig.Money.ToString();
        PlayerPrefs.Save();
        AdsManager.instance.completedAdsReward -= addCoinComplete;
    }
}
