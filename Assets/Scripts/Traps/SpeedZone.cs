using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 2f;
    private PlayerMovement player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        player = collision.GetComponent<PlayerMovement>();
        if (player != null)
            player.moveSpeed *= speedMultiplier;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (player != null)
            player.moveSpeed /= speedMultiplier;
    }
}