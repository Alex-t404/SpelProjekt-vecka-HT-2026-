using UnityEngine; //Alex B.T
using UnityEngine.InputSystem; // Krävs för det nya Input System

public class CameraLook : MonoBehaviour
{
    [SerializeField] private float CameraSensitivity = 100f;
    [SerializeField] private float MinLookDist;
    [SerializeField] private float MaxLookDist;

    private float camLookDistance;

    void Start()
    {
        camLookDistance = transform.localRotation.y;
    }

    void Update()
    {
        // Läser av musens rörelse via det nya systemet
        float mouseX = 0f;
        if (Mouse.current != null)
        {
            mouseX = Mouse.current.delta.x.ReadValue() * Time.deltaTime;
        }

        camLookDistance = Mathf.Clamp(camLookDistance + mouseX * CameraSensitivity, MinLookDist, MaxLookDist);

        transform.localRotation = Quaternion.Euler(0f, camLookDistance, 0f);
    }
}