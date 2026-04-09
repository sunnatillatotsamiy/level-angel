using UnityEngine;

public class PressureButton : MonoBehaviour
{
    [SerializeField] private GameObject[] disappearingBlocks;
    private bool isTriggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player") || isTriggered) return;
        isTriggered = true;

        foreach (var block in disappearingBlocks)
            if (block != null)
                block.SetActive(false);
    }

    public void ResetButton()
    {
        isTriggered = false;
        foreach (var block in disappearingBlocks)
            if (block != null)
                block.SetActive(true);
    }
}