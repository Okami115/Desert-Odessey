using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Configuration")]
public class PlayerConfig : ScriptableObject
{
    [Header("Current Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float fireRate;
    [SerializeField] private float size;
    public float Speed { get => speed; set => speed = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Size { get => size; set => size = value; }

    [Header("Stats Limit")]
    [SerializeField] private int maxUpgrades;
    [SerializeField] private float speedLimit;
    [SerializeField] private float fireRateLimit;
    [SerializeField] private float sizeLimit;
    public int MaxUpgrades { get => maxUpgrades; set => maxUpgrades = value; }
    public float SpeedLimit { get => speedLimit; }
    public float FireRateLimit { get => fireRateLimit; }
    public float SizeLimit { get => sizeLimit; }

    [Header("Skin Config")]
    [SerializeField] private int currentSkin;
    [SerializeField] public List<string> skin;
    public int CurrentSkin { get => currentSkin; set => currentSkin = value; }

    [Header("Money Stat")]
    [SerializeField] private int money;
    public int Money { get => money; set => money = value; }

    [Header("Game Config")]
    [SerializeField] public bool isPause;

    [Header("Enemies")]
    [SerializeField] public int currentEnemies;






}
