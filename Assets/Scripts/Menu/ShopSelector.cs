using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;

    [SerializeField] private TextMeshProUGUI price;
    [SerializeField] private TextMeshProUGUI Money;

    [SerializeField] private TextMeshProUGUI buyButton;

    [SerializeField] private int[] PriceList;
    [SerializeField] private PlayerConfig playerConfig;
    
    [SerializeField] private AnalyticsManager analyticsManager;

    private int SelectorSkin;

    void Start()
    {
        SelectorSkin = 0;

        Money.text = PlayerPrefs.GetInt("Money", 0).ToString();
        
        if (playerConfig.skin[SelectorSkin] == "SELL")
            buyButton.text = "EQUIP";
        else
            buyButton.text = "BUY";

        price.text = playerConfig.skin[SelectorSkin];

        image.sprite = sprites[SelectorSkin];
    }

    public void NextSkin()
    {
        SelectorSkin++;

        if (SelectorSkin > sprites.Length - 1)
            SelectorSkin = sprites.Length - 1;

        if (playerConfig.skin[SelectorSkin] == "SELL")
            buyButton.text = "EQUIP";
        else
            buyButton.text = "BUY";

        price.text = playerConfig.skin[SelectorSkin];

        image.sprite = sprites[SelectorSkin];
    }

    public void PreviousSkin()
    {
        SelectorSkin--;

        if (SelectorSkin < 0)
            SelectorSkin = 0;

        if (playerConfig.skin[SelectorSkin] == "SELL")
            buyButton.text = "EQUIP";
        else
            buyButton.text = "BUY";

        price.text = playerConfig.skin[SelectorSkin];

        image.sprite = sprites[SelectorSkin];
    }

    public void Buy()
    {
        if (playerConfig.skin[SelectorSkin] == "SELL")
        {
            playerConfig.CurrentSkin = SelectorSkin;
            return;
        }

        if (playerConfig.Money >= PriceList[SelectorSkin])
        {
            playerConfig.Money -= PriceList[SelectorSkin];
            Money.text = playerConfig.Money.ToString();
            playerConfig.CurrentSkin = SelectorSkin;
            playerConfig.skin[SelectorSkin] = "SELL";
            buyButton.text = "EQUIP";

            price.text = playerConfig.skin[SelectorSkin];
            
            analyticsManager.RecordBuyEvent(SelectorSkin);

            PlayerPrefs.SetString("Skin " + SelectorSkin.ToString(), playerConfig.skin[SelectorSkin]);
            PlayerPrefs.SetInt("Money", playerConfig.Money);

            PlayerPrefs.Save();
        }
    }

    [ContextMenu("Resert Player prefs")]
    private void ResetPlayerPref()
    {
        PlayerPrefs.SetString("Skin 0", "SELL");
        PlayerPrefs.SetString("Skin 1", PriceList[1].ToString());
        PlayerPrefs.SetString("Skin 2", PriceList[2].ToString());
        PlayerPrefs.SetString("Skin 3", PriceList[3].ToString());
        
        playerConfig.skin[1] = PriceList[1].ToString();
        playerConfig.skin[2] = PriceList[2].ToString();
        playerConfig.skin[3] = PriceList[3].ToString();
        
        playerConfig.Money = 100;
        PlayerPrefs.SetInt("Money", playerConfig.Money);
        
        PlayerPrefs.Save();
    }
}