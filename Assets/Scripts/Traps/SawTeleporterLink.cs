using UnityEngine;

public class SawTeleporterLink : MonoBehaviour
{
    [SerializeField] private SawEnemy giantSaw;
    [SerializeField] private Teleporter teleporter;
    private bool activated = false;

    private void Update()
    {
        if (activated) return;
        if (giantSaw == null || teleporter == null) return;
        if (giantSaw.IsFinished())
        {
            teleporter.ActivateTeleporter();
            activated = true;
        }
    }

    public void ResetLink()
    {
        activated = false;
    }
}