using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Configuration")]
public class PlayerConfig : ScriptableObject
{
    private int money;

    public int Money { get => money; set => money = value; }
}
