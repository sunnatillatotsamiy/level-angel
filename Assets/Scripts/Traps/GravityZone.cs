using UnityEngine;

public class GravityZone : MonoBehaviour
{
    public enum GravityType { Low, Flipped, Normal }
    [SerializeField] private GravityType gravityType = GravityType.Low;
    [SerializeField] private float lowGravityScale = 0.3f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        if (rb == null) return;

        switch (gravityType)
        {
            case GravityType.Low:
                rb.gravityScale = lowGravityScale;
                break;
            case GravityType.Flipped:
                rb.gravityScale = -1f;
                if (pm != null) pm.jumpForce = -Mathf.Abs(pm.jumpForce);
                break;
            case GravityType.Normal:
                rb.gravityScale = 1f;
                if (pm != null) pm.jumpForce = Mathf.Abs(pm.jumpForce);
                break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        Rigidbody2D rb = collision.GetComponent<Rigidbody2D>();
        PlayerMovement pm = collision.GetComponent<PlayerMovement>();
        if (rb == null) return;
        rb.gravityScale = 1f;
        if (pm != null) pm.jumpForce = Mathf.Abs(pm.jumpForce);
    }
}