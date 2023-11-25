using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private PlayerController controller;

    private Vector2 input;

    [SerializeField] private float speed;
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
        input.y = joystickLeft.Vertical;
        input.x = joystickLeft.Horizontal;

        rb.AddForce(speed * input.normalized, ForceMode2D.Force);
    }
}
