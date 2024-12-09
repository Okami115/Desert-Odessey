using UnityEngine;
using UnityEngine.Windows;


public class PlayerShoot : MonoBehaviour
{
    [Header("Player Componentes")]
    [SerializeField] private PlayerController controller;
    [SerializeField] private Joystick joystickRight;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Animator animator;

    [Header("Bullets Factory")]
    [SerializeField] private BulletsConfig bulletConfig;
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
        if (!playerConfig.isPause)
        {
            time += Time.deltaTime;

            input.y = joystickRight.Vertical;
            input.x = joystickRight.Horizontal;

            LockStickShoot();

            if(input.x != 0 || input.y != 0) 
            {
                animator.SetInteger("Direction", SetStateAnimation());
                Shoot(input);
            }
        }
    }

    private void Shoot(Vector3 trajectory)
    {
        if(time> playerConfig.FireRate)
        {
            bulletFactory.Create(trajectory, "Standar", transform);

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

    private int SetStateAnimation()
    {
        int aux;
        if(input.x == 0 && input.y == 1) 
        {
            aux = 2;
        }
        else if (input.x == 0 && input.y == -1)
        {
            aux = 1;
        }
        else if (input.x == 1 && input.y == 0)
        {
            aux = 4;
        }
        else if (input.x == -1 && input.y == 0)
        {
            aux = 3;
        }
        else
        {
            aux = 0;
        }


        return aux;
    }
}
