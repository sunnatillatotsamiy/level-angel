using UnityEngine;

public class PulsatingSaw : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float leftX;
    [SerializeField] private float rightX;
    private bool movingRight = true;

    [Header("Pulsating")]
    [SerializeField] private float minScale = 1f;
    [SerializeField] private float maxScale = 6f;
    [SerializeField] private float pulseSpeed = 2f;
    private bool growing = true;
    private float currentScale;
    private Vector3 startPosition;

    private void Start()
    {
        currentScale = minScale;
        transform.localScale = Vector3.one * currentScale;
        startPosition = transform.position;
    }

    private void Update()
    {
        Vector3 moveDir = movingRight ? Vector3.right : Vector3.left;
        transform.position += moveDir * speed * Time.deltaTime;

        if (transform.position.x >= rightX)
            movingRight = false;
        else if (transform.position.x <= leftX)
            movingRight = true;

        if (growing)
        {
            currentScale += pulseSpeed * Time.deltaTime;
            if (currentScale >= maxScale)
                growing = false;
        }
        else
        {
            currentScale -= pulseSpeed * Time.deltaTime;
            if (currentScale <= minScale)
                growing = true;
        }

        transform.localScale = Vector3.one * currentScale;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        RespawnManager respawn = FindObjectOfType<RespawnManager>();
        if (respawn != null)
            respawn.Respawn();
    }

    public void ResetSaw()
    {
        transform.position = startPosition;
        currentScale = minScale;
        transform.localScale = Vector3.one * currentScale;
        growing = true;
        movingRight = true;
    }
}             