using UnityEngine;

public class SawEnemy : MonoBehaviour
{
    public enum MoveDirection { Left, Right }
    [SerializeField] private MoveDirection direction = MoveDirection.Left;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float startX;
    [SerializeField] private float endX;
    private bool isActive = false;
    private SpriteRenderer sr;
    private Collider2D col;
    [Header("Audio")]
    [SerializeField] private AudioClip activateSound;
    private AudioSource audioSource;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        sr.enabled = false;
        col.enabled = false;
    }

    private void Update()
    {
        if (!isActive) return;

        Vector3 moveDir = direction == MoveDirection.Left ? Vector3.left : Vector3.right;
        transform.position += moveDir * speed * Time.deltaTime;

        bool reached = direction == MoveDirection.Left
            ? transform.position.x <= endX
            : transform.position.x >= endX;

        if (reached)
        {
            isActive = false;
            sr.enabled = false;
            col.enabled = false;
        }
    }

    public void Activate()
    {
        transform.position = new Vector3(startX, transform.position.y, 0);
        sr.enabled = true;
        col.enabled = true;
        isActive = true;
        if (audioSource != null && activateSound != null)
        {
            audioSource.clip = activateSound;
            audioSource.Play();
            Debug.Log("[SAW] audioSource: " + (audioSource != null) + " activateSound: " + (activateSound != null));
        }
    }

    public void ResetSaw()
    {
        isActive = false;
        transform.position = new Vector3(startX, transform.position.y, 0);
        sr.enabled = false;
        col.enabled = false;
        if (audioSource != null)
            audioSource.Stop();
    }

    public bool IsFinished()
    {
        return !isActive && col.enabled == false && sr.enabled == false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        RespawnManager respawn = FindObjectOfType<RespawnManager>();
        if (respawn != null)
            respawn.Respawn();
    }
}