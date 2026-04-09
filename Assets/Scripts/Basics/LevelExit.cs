using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelExit : MonoBehaviour
{
    [SerializeField] private string nextSceneName = "";
    [Header("Meme Sound")]
    [SerializeField] private AudioClip victorySound;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private float delayBeforeLoad = 2f;
    [SerializeField] private CreditsRoll creditsRoll;

    private bool isTriggered = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (creditsRoll != null)
        {
            creditsRoll.StartCredits();
            collision.GetComponent<PlayerMovement>().Die();
            return;
        }
        if (!string.IsNullOrWhiteSpace(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
        Debug.Log("[EXIT] Player entered. creditsRoll: " + (creditsRoll != null));
    }

    private IEnumerator WinSequence()
    {
        if (victorySound != null && audioSource != null)
            audioSource.PlayOneShot(victorySound);
        yield return new WaitForSeconds(delayBeforeLoad);
        if (!string.IsNullOrWhiteSpace(nextSceneName))
            SceneManager.LoadScene(nextSceneName);
    }
}