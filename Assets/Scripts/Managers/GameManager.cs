using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PlayerStats playerConfig;


    public event Action playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerConfig.HP <= 0)
        {
            playerDeath?.Invoke();
            Time.timeScale = 0.0f;
        }
    }
}
