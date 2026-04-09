using System.Collections;
using UnityEngine;
public class CollapsingPlatform : MonoBehaviour
{
    public float delay = 1f;
    public float shakeAmount = 0.05f;
    [Header("Meme Sound")]
    [SerializeField] private AudioClip collapseSound;
    [SerializeField] private AudioSource audioSource;
    private bool isTriggered = false;
    private Rigidbody2D rb;
    private Vector3 originalPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        originalPosition = transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!isTriggered && collision.gameObject.CompareTag("Player"))
        {
            isTriggered = true;
            StartCoroutine(CollapseSequence());
        }
    }

    private IEnumerator CollapseSequence()
    {
        if (collapseSound != null && audioSource != null)
            audioSource.PlayOneShot(collapseSound, 0.4f);
        float elapsed = 0f;
        while (elapsed < delay)
        {
            transform.position = originalPosition + (Vector3)Random.insideUnitCircle * shakeAmount;
            elapsed += Time.deltaTime;
            yield return null;
        }
        Collapse();
    }

    public void Collapse()
    {
        transform.position = originalPosition;
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void Reset()
    {
        isTriggered = false;
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.velocity = Vector2.zero;
        transform.position = originalPosition;
    }
}