using UnityEngine;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Door Door;

    [SerializeField] private PowerSystem Power;

    private void OnMouseDown()
    {
        Door.IsOpen = !Door.IsOpen;

        if (Door.IsOpen)
        {
            Power.SystemsOn -= 1;
        }
        else
        {
            Power.SystemsOn += 1;
        }
    }
}
