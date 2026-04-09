using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeField] private Transform destination;
    [SerializeField] private bool startActive = true;
    [Header("Audio")]
    [SerializeField] private AudioClip teleportSound;
    private AudioSource audioSource;
    private bool isActive;
    private bool isTriggered = false;

    private void Start()
    {
        isActive = startActive;
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.spatialBlend = 0f;
        audioSource.playOnAwake = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || isTriggered || !isActive) return;
        isTriggered = true;

        if (audioSource != null && teleportSound != null)
            audioSource.PlayOneShot(teleportSound);

        collision.transform.position = new Vector3(destination.position.x, destination.position.y, 0);

        TimedPlatform[] timedPlatforms = FindObjectsByType<TimedPlatform>(FindObjectsSortMode.None);
        foreach (var tp in timedPlatforms)

            tp.ResetPlatform();

        Invoke(nameof(ResetTrigger), 1f);
    }

    private void ResetTrigger()
    {
        isTriggered = false;
    }

    public void ActivateTeleporter()
    {
        isActive = true;
    }

    public void ResetTeleporter()
    {
        isActive = startActive;
        isTriggered = false;
    }
}