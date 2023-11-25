using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public Action<Vector3> playerMove;
    public Action<Vector3> playerShoot;

    public void OnMove(InputValue input)
    {
        playerMove?.Invoke(input.Get<Vector2>()); 
    }

    public void OnShoot(InputValue input)
    {
        playerShoot?.Invoke(input.Get<Vector2>());
    }

}
