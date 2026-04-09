using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    [SerializeField] private GameObject doorPlatform;
    private bool isOpen = false;

    public void OpenDoor()
    {
        if (!isOpen)
        {
            isOpen = true;
            doorPlatform.SetActive(false);
            Invoke(nameof(CloseDoor), 3f);
        }
    }

    void CloseDoor()
    {
        isOpen = false;
        doorPlatform.SetActive(true);
    }
}