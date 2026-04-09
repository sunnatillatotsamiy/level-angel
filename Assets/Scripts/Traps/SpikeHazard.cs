using UnityEngine;

public class SpikeHazard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        RespawnManager respawn = FindObjectOfType<RespawnManager>();
        if (respawn != null)
            respawn.Respawn();
    }
}