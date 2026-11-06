using UnityEngine;
using UnityEngine.InputSystem; //Alex B.T

public class ToggleImageUI : MonoBehaviour
{
    [SerializeField] private GameObject imageToToggle;

    private void Update()
    {
        // Kollar om M-tangenten trycktes ner i denna frame
        if (Keyboard.current != null && Keyboard.current.mKey.wasPressedThisFrame)
        {
            if (imageToToggle != null)
            {
                imageToToggle.SetActive(!imageToToggle.activeSelf);
            }
        }
    }
}

