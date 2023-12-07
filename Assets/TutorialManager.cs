using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private Sprite[] tutorial;
    [SerializeField] private Image image;

    private int SelectorTuto;

    private void Start()
    {
        SelectorTuto = 0;
        image.sprite = tutorial[SelectorTuto];
    }
    public void nextTuto()
    {
        SelectorTuto++;

        if (SelectorTuto > tutorial.Length - 1)
            SelectorTuto = tutorial.Length - 1;

        image.sprite = tutorial[SelectorTuto];
    }

    public void previousTuto()
    {
        SelectorTuto--;

        if (SelectorTuto < 0)
            SelectorTuto = 0;

        image.sprite = tutorial[SelectorTuto];
    }
}
