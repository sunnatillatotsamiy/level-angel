using UnityEngine;

public class WindZone : MonoBehaviour
{
    public enum WindDirection { Right, Left, Up, Down }
    [SerializeField] private WindDirection windDirection = WindDirection.Right;
    [SerializeField] private float windForce = 5f;
    [SerializeField] private SawEnemy sawToActivate;
    [SerializeField] private GameObject speedZoneToDisable;
    private bool sawActivated = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (!sawActivated && sawToActivate != null)
        {
            sawActivated = true;
            sawToActivate.Activate();
        }
        if (speedZoneToDisable != null)
            speedZoneToDisable.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        if (rb == null) return;
        Vector2 force = windDirection switch
        {
            WindDirection.Right => Vector2.right,
            WindDirection.Left => Vector2.left,
            WindDirection.Up => Vector2.up,
            WindDirection.Down => Vector2.down,
            _ => Vector2.zero
        };
        rb.AddForce(force * windForce);
    }

    public void ResetZone()
    {
        sawActivated = false;
        if (speedZoneToDisable != null)
            speedZoneToDisable.SetActive(true);
        if (sawToActivate != null)
            sawToActivate.ResetSaw();
    }
}