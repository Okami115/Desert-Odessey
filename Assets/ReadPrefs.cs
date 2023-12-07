using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadPrefs : MonoBehaviour
{
    [SerializeField] private PlayerConfig playerConfig;

    private void Start()
    {
        playerConfig.Money = PlayerPrefs.GetInt("Money", 15);
        playerConfig.CurrentSkin = PlayerPrefs.GetInt("Current Skin", 0);

        for (int i = 0; i < playerConfig.skin.Count - 1; i++) 
        {
            if (i == 0)
                playerConfig.skin[i] = PlayerPrefs.GetString("Skin 0", "SELL");

            playerConfig.skin[i] = PlayerPrefs.GetString("Skin " + i.ToString(), (i * 15).ToString());

        }
    }
}
