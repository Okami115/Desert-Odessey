using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopSelector : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites;
    [SerializeField] private Image image;

    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private TextMeshProUGUI Money;

    [SerializeField] private TextMeshProUGUI buyButton;

    [SerializeField] private int[] PriceList;
    [SerializeField] private PlayerConfig playerConfig;

    private int SelectorSkin;

    void Start()
    {
        SelectorSkin = 0;

        PlayerPrefs.SetString("Skin 0", "SELL");
        PlayerPrefs.SetString("Skin 1", PriceList[1].ToString());
        PlayerPrefs.SetString("Skin 2", PriceList[2].ToString());
        PlayerPrefs.SetString("Skin 3", PriceList[3].ToString());

        Money.text = PlayerPrefs.GetInt("Money", 0).ToString();

        if (playerConfig.skin[SelectorSkin] == "SELL")
            buyButton.text = "EQUIP";
        else
            buyButton.text = "BUY";

        text.text = playerConfig.skin[SelectorSkin];

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

        text.text = playerConfig.skin[SelectorSkin];

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

        text.text = playerConfig.skin[SelectorSkin];

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

            if (playerConfig.skin[SelectorSkin] == "SELL")
                buyButton.text = "EQUIP";
            else
                buyButton.text = "BUY";

            text.text = playerConfig.skin[SelectorSkin];

            for (int i = 0; i < PriceList.Length; i++)
            {
                PlayerPrefs.SetString("Skin " + i.ToString(), playerConfig.skin[SelectorSkin]);
            }

            PlayerPrefs.Save();

        }
    }
}
