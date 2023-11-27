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

    private int SelectorSkin;

    // Start is called before the first frame update
    void Start()
    {
        SelectorSkin = 0;
        image.sprite = sprites[SelectorSkin];

        PlayerPrefs.GetString("Skin 0", "SELL");
        PlayerPrefs.GetString("Skin 1", PriceList[1].ToString());
        PlayerPrefs.GetString("Skin 2", PriceList[2].ToString());
        PlayerPrefs.GetString("Skin 3", PriceList[3].ToString());

        PlayerPrefs.SetInt("Money", 100);

        Money.text = PlayerPrefs.GetInt("Money", 0).ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextSkin()
    {
        SelectorSkin++;

        if (SelectorSkin > sprites.Length)
                SelectorSkin = sprites.Length;

        if (PlayerPrefs.GetString("Skin " + SelectorSkin.ToString()) == "SELL")
            buyButton.text = "SELL";

        text.text = PlayerPrefs.GetString("Skin " + SelectorSkin.ToString(), PriceList[SelectorSkin].ToString());

        image.sprite = sprites[SelectorSkin];
    }

    public void PreviousSkin()
    {
        SelectorSkin--;

        if (SelectorSkin < 0)
            SelectorSkin = 0;

        if (PlayerPrefs.GetString("Skin " + SelectorSkin.ToString()) == "SELL")
            buyButton.text = "SELL";

        text.text = PlayerPrefs.GetString("Skin " + SelectorSkin.ToString(), PriceList[SelectorSkin].ToString());

        image.sprite = sprites[SelectorSkin];
    }

    public void Buy()
    {
        if (PlayerPrefs.GetString("Skin " + SelectorSkin.ToString()) == "SELL")
        {
            PlayerPrefs.SetInt("Skin", SelectorSkin);
            return;
        }

        if (PlayerPrefs.GetInt("Money", 0) >= PriceList[SelectorSkin])
        {
            int money = PlayerPrefs.GetInt("Money", 0);

            PlayerPrefs.SetInt("Money", money - PriceList[SelectorSkin]);
            Money.text = PlayerPrefs.GetInt("Money", 0).ToString();
            PlayerPrefs.SetInt("Skin", SelectorSkin);
            PlayerPrefs.SetString("Skin " + SelectorSkin.ToString(), "SELL");
        }
    }
}
