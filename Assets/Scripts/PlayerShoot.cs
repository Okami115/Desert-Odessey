using UnityEngine;
using UnityEngine.Windows;


public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private PlayerController controller;

    [SerializeField] private GameObject prefabBullte;

    [SerializeField] private float fireRate;

    [SerializeField] private Joystick joystickRight;
    public Vector2 input;

    private float time;

    void Start()
    {
        controller.playerShoot += Shoot;
    }

    private void Update()
    {
        time += Time.deltaTime;

        input.y = joystickRight.Vertical;
        input.x = joystickRight.Horizontal;

        if(input.y != 0 || input.x != 0)
        {
            LockStickShoot();

            Shoot(input);
        }
    }
    private void Shoot(Vector3 trajectory)
    {
        if(time> fireRate)
        {
            GameObject bullet = Instantiate(prefabBullte, gameObject.transform);

            Bullet newBullet = bullet.GetComponent<Bullet>();

            if (newBullet != null)
            {
                newBullet.SetTrajectory(trajectory);
            }

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
