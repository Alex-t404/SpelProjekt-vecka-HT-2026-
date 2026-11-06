using UnityEngine;
using UnityEngine.InputSystem;

public class ToggleImageUI : MonoBehaviour
{
    [SerializeField] private GameObject imageToToggle;
    public void OnToggleImage(InputAction.CallbackContext context)
    {
        // Vi vill bara reagera när knappen trycks ned (Started), inte när den släpps.
        if (context.started)
        {
            if (imageToToggle != null)
            {
                // Växlar active-statusen, om den var sann blir den falsk. 
                imageToToggle.SetActive(!imageToToggle.activeSelf);
            }
        }
    }
}
