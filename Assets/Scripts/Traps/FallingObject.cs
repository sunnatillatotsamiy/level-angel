using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.7f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            RespawnManager respawn = collision.gameObject.GetComponent<RespawnManager>();
            if (respawn != null)
                respawn.Respawn();
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}