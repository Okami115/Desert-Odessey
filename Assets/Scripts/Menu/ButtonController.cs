using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonController : MonoBehaviour
{
    [Header("Panels")]
    [SerializeField] private GameObject menu;
    [SerializeField] private GameObject shop;
    [SerializeField] private GameObject howToPlay;
    [SerializeField] private GameObject logger;

    public void Play()
    {
        SceneManager.LoadScene(2);
    }

    public void Back()
    {
        menu.SetActive(true);
        shop.SetActive(false);
        howToPlay.SetActive(false);
        logger.SetActive(false);
    }

    public void Shop()
    {
        menu.SetActive(false);
        shop.SetActive(true);
        howToPlay.SetActive(false);
        logger.SetActive(false);
    }

    public void Logger()
    {
        menu.SetActive(false);
        shop.SetActive(false);
        howToPlay.SetActive(false);
        logger.SetActive(true);
    }

    public void Tutorial()
    {
        menu.SetActive(false);
        shop.SetActive(false);
        howToPlay.SetActive(true);
        logger.SetActive(false);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
