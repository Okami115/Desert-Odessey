using UnityEngine;
using UnityEngine.Windows;


public class PlayerShoot : MonoBehaviour
{
    [Header("Player Componentes")]
    [SerializeField] private PlayerController controller;
    [SerializeField] private Joystick joystickRight;

    [Header("Bullets Factory")]
    [SerializeField] private BulletsConfig bulletConfig;
    [SerializeField] private float fireRate;
    private BulletFactory bulletFactory;

    private Vector2 input;

    private float time;
    void Start()
    {
        bulletFactory = new BulletFactory(bulletConfig);
        controller.playerShoot += Shoot;
    }

    private void Update()
    {
        time += Time.deltaTime;

        input.y = joystickRight.Vertical;
        input.x = joystickRight.Horizontal;

        LockStickShoot();

        if(input.x == 0 && input.y == 0) 
        { 
        
        }
        else
        {
            Shoot(input);
        }
    }

    private void Shoot(Vector3 trajectory)
    {
        if(time> fireRate)
        {
            bulletFactory.Create(trajectory, "Standar");

            if (trajectory != Vector3.zero)
            {
                float angle = Mathf.Atan2(trajectory.y, trajectory.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            time = 0;
        }
    }

    private void LockStickShoot()
    {
        // Lock X axis
        if (input.x > 0 && input.x < 0.5f) { input.x = 0; }
        if (input.x > 0 && input.x > 0.5f) { input.x = 1; }
        if (input.x < 0 && input.x > -0.5f) { input.x = 0; }
        if (input.x < 0 && input.x < -0.5f) { input.x = -1; }

        // Lock Y axis
        if (input.y > 0 && input.y < 0.5f) { input.y = 0; }
        if (input.y > 0 && input.y > 0.5f) { input.y = 1; }
        if (input.y < 0 && input.y > -0.5f) { input.y = 0; }
        if (input.y < 0 && input.y < -0.5f) { input.y = -1; }

        // The vertical axis is prioritized in the diagonals
        if (input.x == 1 && input.y == 1) { input.y = 0; }
        if(input.x == -1 && input.y == -1) { input.y = 0; }
        if(input.x == 1 && input.y == -1) { input.y = 0; }
        if(input.x == -1 && input.y == 1) { input.y = 0; }
    }
}
