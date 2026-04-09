using UnityEngine;

public class GiantSawTrigger : MonoBehaviour
{
    [SerializeField] private SawEnemy giantSaw;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || triggered) return;
        triggered = true;
        if (giantSaw != null)
            giantSaw.Activate();
    }

    public void ResetTrigger()
    {
        triggered = false;
    }
}