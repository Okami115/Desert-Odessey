using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerController controller;
    [SerializeField] private PlayerConfig playerConfig;
    [SerializeField] private Animator animator;
    [SerializeField] private float speedMultiplier;

    private Vector2 input;

    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private BoxCollider2D boxCollider;

    [SerializeField] private Joystick joystickLeft;

    void Start()
    {
        controller.playerMove += Move;
    }

    private void Move(Vector3 direction)
    {
        input = direction;
    }

    private void Update()
    {
        if (playerConfig != null)
        {
            if (!playerConfig.isPause)
            {
                input.y = joystickLeft.Vertical;
                input.x = joystickLeft.Horizontal;

                if (input.x == 0 && input.y == 0)
                {
                    animator.SetInteger("Direction", 0);
                }
                
                rb.AddForce(input.normalized * Time.deltaTime * playerConfig.Speed * speedMultiplier,
                    ForceMode2D.Force);
            }
            else
            {
                animator.SetInteger("Direction", 0);
            }
        }
        else
        {
            Debug.Log("No player config");
        }
    }

    private void LateUpdate()
    {
        if (input.x != 0 || input.y != 0)
        {
            animator.SetInteger("Direction", 1);
        }
    }
}