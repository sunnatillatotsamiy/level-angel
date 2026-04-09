using UnityEngine;

public class HazardBase : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnManager respawn = collision.GetComponent<RespawnManager>();
            if (respawn != null)
            {
                respawn.Respawn();
            }
        }
    }
}
