using System.Collections;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [Header("Spawner Settings")]
    [SerializeField] private GameObject fallingObjectPrefab;
    [SerializeField] private float minInterval = 0.3f;
    [SerializeField] private float maxInterval = 1.5f;
    [SerializeField] private float spawnWidth = 50f;
    [SerializeField] private bool startActive = false;
    [SerializeField] private Transform player;
    [SerializeField] private float spawnRadius = 15f;
    private bool isActive = false;

    private void Start()
    {
        if (startActive)
        {
            isActive = true;
            StartCoroutine(SpawnLoop());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isActive)
        {
            isActive = true;
            StartCoroutine(SpawnLoop());
        }
    }

    private IEnumerator SpawnLoop()
    {
        while (isActive)
        {
            float waitTime = Random.Range(minInterval, maxInterval);
            yield return new WaitForSeconds(waitTime);
            SpawnObject();
        }
    }

    private void SpawnObject()
    {
        float centerX = player != null ? player.position.x : transform.position.x;
        float randomX = centerX + Random.Range(-spawnRadius, spawnRadius);
        Vector3 spawnPos = new Vector3(randomX, transform.position.y, 0);
        Instantiate(fallingObjectPrefab, spawnPos, Quaternion.identity);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !startActive)
            isActive = false;
    }

    public void ResetSpawner()
    {
        isActive = false;
        StopAllCoroutines();

        FallingObject[] existing = FindObjectsByType<FallingObject>(FindObjectsSortMode.None);
        foreach (var obj in existing)
            Destroy(obj.gameObject);

        if (startActive)
        {
            isActive = true;
            StartCoroutine(SpawnLoop());
        }
    }
}