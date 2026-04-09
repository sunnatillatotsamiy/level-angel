using UnityEngine;
using TMPro;

public class HintTrigger : MonoBehaviour
{
    [TextArea]
    public string hintMessage;
    public float displayTime = 3f;
    [SerializeField] private TextMeshProUGUI hintText;
    private bool triggered = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggered || !collision.CompareTag("Player")) return;
        triggered = true;
        hintText.text = hintMessage;
        hintText.gameObject.SetActive(true);
        Invoke(nameof(HideHint), displayTime);
    }

    void HideHint()
    {
        hintText.gameObject.SetActive(false);
    }
}