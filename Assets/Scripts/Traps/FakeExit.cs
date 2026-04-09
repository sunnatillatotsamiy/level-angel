using UnityEngine;
public class FakeExit : MonoBehaviour
{
    [SerializeField] private Transform fakeRespawnPoint;
    [SerializeField] private AudioClip fakeExitSound;
    [SerializeField] private AudioSource audioSource;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        RespawnManager respawn = collision.GetComponent<RespawnManager>();
        if (respawn == null) return;

        if (fakeRespawnPoint != null)
            respawn.SetCheckpoint(fakeRespawnPoint.position);

        if (fakeExitSound != null && audioSource != null)
            audioSource.PlayOneShot(fakeExitSound);

        respawn.RespawnNoScreen();
    }
}