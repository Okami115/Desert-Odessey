using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{

    [Header("HUD")]
    [SerializeField] private TextMeshProUGUI round;
    [SerializeField] private TextMeshProUGUI money;
    [SerializeField] private RectTransform HP;
    [SerializeField] private RectTransform XP;
    [SerializeField] private PlayerStats player;

    [Header("Screens")]
    [SerializeField] private GameObject DeadScreen;
    [SerializeField] private GameObject LevelUpScreen;

    private void OnEnable()
    {
        player.updateHP += UpdateHPBar;
        player.updateXP += UpdateXPBar;
        player.updateMoney += UpdateMoneyText;
        player.levelUp += ShowLevelUpScreen;
    }

    private void OnDisable()
    {
        player.updateHP -= UpdateHPBar;
        player.updateXP -= UpdateXPBar;
        player.updateMoney -= UpdateMoneyText;
        player.levelUp -= ShowLevelUpScreen;
        
    }


    private void UpdateXPBar(int currentXP, int maxXP)
    {
        float aux1 = currentXP;
        float aux2 = maxXP;

        XP.localScale = new Vector3(aux1 / aux2, 1, 1);
    }

    private void UpdateHPBar(int currentHP, int maxHP)
    {
        float aux1 = currentHP;
        float aux2 = maxHP;

        HP.localScale = new Vector3(aux1 / aux2, 1, 1);
    }

    private void UpdateMoneyText(string text)
    {
        money.text = text;
    }

    private void UpdateRoundText(string text)
    {
        round.text = text;
    }

    private void ShowLevelUpScreen()
    {
        DeadScreen.SetActive(true);
    }
}
