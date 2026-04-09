using UnityEngine;
public class ParallaxLayer : MonoBehaviour
{
    [Range(0f, 1f)]
    public float parallaxFactor = 0.2f;
    private Transform cam;
    private Vector3 lastCamPos;
    void Start()
    {
        if (Camera.main == null)
        {
            enabled = false;
            return;
        }
        cam = Camera.main.transform;
        lastCamPos = cam.position;
    }
    void LateUpdate()
    {
        if (cam == null) return;
        Vector3 delta = cam.position - lastCamPos;
        transform.position += new Vector3(delta.x * parallaxFactor, delta.y * parallaxFactor, 0);
        lastCamPos = cam.position;
    }
}