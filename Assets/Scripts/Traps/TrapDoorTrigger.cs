using UnityEngine;

public class TrapDoorTrigger : MonoBehaviour
{
    [SerializeField] private TrapDoor trapDoor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;
        if (trapDoor != null)
            trapDoor.OpenDoor();
    }
}