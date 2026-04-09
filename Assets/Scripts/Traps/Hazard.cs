using UnityEngine;
public class Hazard : MonoBehaviour
{
    [SerializeField] private Transform specificRespawnPoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            RespawnManager respawn = collision.GetComponent<RespawnManager>();
            if (respawn != null)
            {
                if (specificRespawnPoint != null)
                    respawn.SetCheckpoint(specificRespawnPoint.position);

                respawn.Respawn();
            }
        }
    }
}