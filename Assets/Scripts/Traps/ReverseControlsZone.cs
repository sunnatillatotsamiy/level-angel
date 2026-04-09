using UnityEngine;

public class ReverseControlsZone : MonoBehaviour
{
    [SerializeField] private float transitionSpeed = 3f;
    private static ReverseControlsZone activeZone = null;
    private PlayerMovement pm;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        pm = collision.GetComponent<PlayerMovement>();
        activeZone = this;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (activeZone == this)
            activeZone = null;
    }

    private void Update()
    {
        if (pm == null) return;

        if (activeZone == this)
        {
            pm.reverseAmount = Mathf.MoveTowards(pm.reverseAmount, -1f, transitionSpeed * Time.deltaTime);
        }
        else if (activeZone == null)
        {
            pm.reverseAmount = Mathf.MoveTowards(pm.reverseAmount, 1f, transitionSpeed * Time.deltaTime);
        }
    }
}