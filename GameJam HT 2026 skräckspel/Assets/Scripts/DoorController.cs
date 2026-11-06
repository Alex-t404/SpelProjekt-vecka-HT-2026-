using UnityEngine;

public class DoorController : MonoBehaviour //Alex B.T
{
    [SerializeField] private Door door;

    private void OnMouseDown()
    {
        TriggerClick();
    }

    public void TriggerClick()
    {
        if (door != null)
        {
            door.ToggleDoor();
        }
    }
}
