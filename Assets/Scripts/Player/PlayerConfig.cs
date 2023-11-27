using UnityEngine;

[CreateAssetMenu(menuName = "Player/Player Configuration")]
public class PlayerConfig : ScriptableObject
{
    [SerializeField] private float speed;
    [SerializeField] private float fireRate;
    [SerializeField] private float size;

    [SerializeField] private float speedLimit;
    [SerializeField] private float fireRateLimit;
    [SerializeField] private float sizeLimit;

    private int money;

    public int Money { get => money; set => money = value; }
    public float Speed { get => speed; set => speed = value; }
    public float FireRate { get => fireRate; set => fireRate = value; }
    public float Size { get => size; set => size = value; }

    public float SpeedLimit { get => speedLimit;}
    public float FireRateLimit { get => fireRateLimit;}
    public float SizeLimit { get => sizeLimit;}

    
}
