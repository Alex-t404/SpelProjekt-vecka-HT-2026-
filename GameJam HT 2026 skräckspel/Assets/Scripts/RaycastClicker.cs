using UnityEngine;
using UnityEngine.InputSystem;

public class RaycastClicker : MonoBehaviour
{
    [SerializeField] private LayerMask clickableLayers = ~0; // Tillåt klick på alla lager som standard

    void Update()
    {
        // Kontrollerar om vänster musknapp trycktes ned i det nya Input System
        if (Mouse.current != null && Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, clickableLayers))
            {
                // Om vi klickar på dörrknappen
                DoorController doorBtn = hit.collider.GetComponent<DoorController>();
                if (doorBtn != null)
                {
                    doorBtn.TriggerClick();
                    return;
                }

                // Om vi klickar på ljusknappen
                LightController lightBtn = hit.collider.GetComponent<LightController>();
                if (lightBtn != null)
                {
                    lightBtn.TriggerClick();
                    return;
                }
            }
        }
    }
}