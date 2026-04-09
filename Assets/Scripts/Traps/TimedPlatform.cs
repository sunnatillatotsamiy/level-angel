using UnityEngine;

public class TimedPlatform : MonoBehaviour
{
    [SerializeField] private float disappearDelay = 2f;
    private SpriteRenderer sr;
    private Collider2D col;
    private bool playerOnPlatform = false;
    private float timer;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (!playerOnPlatform) return;
        timer += Time.deltaTime;
        if (timer >= disappearDelay)
        {
            sr.enabled = false;
            col.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        playerOnPlatform = true;
        timer = 0f;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;
        playerOnPlatform = false;
        timer = 0f;
    }

    public void ResetPlatform()
    {
        sr.enabled = true;
        col.enabled = true;
        playerOnPlatform = false;
        timer = 0f;
    }
}