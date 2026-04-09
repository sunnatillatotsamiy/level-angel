using UnityEngine;
public class Checkpoint : MonoBehaviour
{
    private Animator animator;
    private bool isActivated = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActivated)
        {
            RespawnManager respawn = collision.GetComponent<RespawnManager>();
            if (respawn != null)
            {
                respawn.SetCheckpoint(transform.position);
                isActivated = true;
                if (animator != null)
                    animator.SetBool("IsActive", true);
            }
        }
    }
}