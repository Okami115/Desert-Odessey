using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform playerPos;

    [SerializeField] private float cameraDistance;

    void Update()
    {
        transform.position = newPos(playerPos.position);
    }

    private Vector3 newPos(Vector3 pos)
    {
        return new Vector3(pos.x, pos.y, cameraDistance);
    }
}
