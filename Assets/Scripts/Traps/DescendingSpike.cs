using UnityEngine;

public class DescendingSpike : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private float stopY = -20f;
    private float startY;
    private bool isActive = false;

    private void Start()
    {
        startY = transform.position.y;
    }

    private void Update()
    {
        if (!isActive) return;
        if (transform.position.y <= stopY)
        {
            isActive = false;
            return;
        }
        transform.position += Vector3.down * speed * Time.deltaTime;
    }

    public void Activate()
    {
        isActive = true;
    }

    public void ResetSpike()
    {
        isActive = false;
        transform.position = new Vector3(transform.position.x, startY, 0);
    }
}