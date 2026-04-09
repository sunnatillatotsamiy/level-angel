using UnityEngine;

public class TriggerTrap : MonoBehaviour
{
    public GameObject trap;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && trap != null)
        {
            trap.SetActive(!trap.activeSelf);
        }
    }
}
