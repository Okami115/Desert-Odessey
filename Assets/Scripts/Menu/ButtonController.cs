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

    public void Exit()
    {
        Application.Quit();
    }
}
