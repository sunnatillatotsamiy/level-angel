using UnityEngine;

public class SpikeActivator : MonoBehaviour
{
    [SerializeField] private DescendingSpike[] spikes;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || triggered) return;
        triggered = true;
        foreach (var spike in spikes)
            spike.Activate();
    }

    public void ResetActivator()
    {
        triggered = false;
    }
}