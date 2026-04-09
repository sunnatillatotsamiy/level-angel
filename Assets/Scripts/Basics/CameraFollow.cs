using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;   // assign your player in inspector
    public float smoothSpeed = 0.125f;
    public Vector3 offset;     // small offset if needed

    void LateUpdate()
    {
        if (player != null)
        {
            Vector3 desiredPosition = player.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
}
