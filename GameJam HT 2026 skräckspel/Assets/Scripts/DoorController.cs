 //Alex B.T
using UnityEngine;
using UnityEngine.InputSystem;

public class DoorController : MonoBehaviour
{
    [SerializeField] private Door Door;

    [SerializeField] private PowerSystem Power;

    Camera cam;
    [SerializeField] LayerMask mask;

    private void Start()
    {
        cam = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit, 10000))
        {
            if (Mouse.current.leftButton.wasPressedThisFrame)
            {
                print("knapp");
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
    }

    private void OnMouseDown()
    {
        
    }

    private void OnMouseOver()
    {
        print("hej");
    }


}
