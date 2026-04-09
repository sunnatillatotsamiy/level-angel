using UnityEngine;
using TMPro;

public class CreditsRoll : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 50f;
    [SerializeField] private RectTransform creditsText;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private float startDelay = 1f;
    private bool isPlaying = false;
    private float timer = 0f;
    private Vector2 startPosition;

    private void Start()
    {
        creditsPanel.SetActive(false);
    }

    public void StartCredits()
    {
        creditsPanel.SetActive(true);
        startPosition = creditsText.anchoredPosition;
        timer = 0f;
        isPlaying = true;
    }

    private void Update()
    {
        if (!isPlaying) return;
        timer += Time.deltaTime;
        if (timer < startDelay) return;
        creditsText.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}