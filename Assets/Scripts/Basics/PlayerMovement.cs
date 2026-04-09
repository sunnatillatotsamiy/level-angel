using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius = 0.15f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Visual")]
    [SerializeField] private Transform visual;

    [Header("Sound Effects")]
    public AudioClip footstepSfx;
    public AudioClip jumpSfx;
    public AudioClip landSfx;
    
    [Header("Audio Sources")]
    [SerializeField] private AudioSource sfxSource;
    [SerializeField] private AudioSource footstepSource;

    private Rigidbody2D rb;
    private Animator animator;
    private bool isGrounded;
    private bool wasGrounded;
    private Vector3 visualOriginalScale;

    [HideInInspector] public bool isDead = false;
    [HideInInspector] public bool controlsReversed = false;

    [Header("Meme Sounds")]
    public AudioClip deathSound;

    [HideInInspector] public float reverseAmount = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = visual.GetComponent<Animator>();
        visualOriginalScale = visual.localScale;
    }

    void Update()
    {
        if (isDead) return;

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float move = Input.GetAxis("Horizontal") * reverseAmount;

        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);
        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("IsGrounded", isGrounded);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            if (jumpSfx != null)
                sfxSource.PlayOneShot(jumpSfx);
        }

        if (!wasGrounded && isGrounded)
        {
            if (landSfx != null)
                sfxSource.PlayOneShot(landSfx);
        }

        if (isGrounded && Mathf.Abs(rb.velocity.x) > 0.1f)
        {
            if (!footstepSource.isPlaying)
            {
                footstepSource.clip = footstepSfx;
                footstepSource.loop = true;
                footstepSource.Play();
            }
        }
        else
        {
            if (footstepSource.isPlaying)
            {
                footstepSource.Stop();
                footstepSource.loop = false;
            }
        }

        wasGrounded = isGrounded;

        if (move != 0)
        {
            visual.localScale = new Vector3(
                Mathf.Sign(move) * visualOriginalScale.x,
                visualOriginalScale.y,
                visualOriginalScale.z
            );
        }
    }

    public void Die()
    {
        isDead = true;
        controlsReversed = false;
        rb.velocity = Vector2.zero;
        footstepSource.Stop();
        animator.SetBool("IsDead", true);
        reverseAmount = 1f;
        GetComponent<Collider2D>().enabled = false;
    }

    public void Revive()
    {
        isDead = false;
        visual.localScale = visualOriginalScale;
        animator.SetBool("IsDead", false);
        GetComponent<Collider2D>().enabled = true;
    }

    public IEnumerator ReverseControls(float duration)
    {
        controlsReversed = true;
        yield return new WaitForSeconds(duration);
        controlsReversed = false;
    }

    void OnDrawGizmos()
    {
        if (groundCheck == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}