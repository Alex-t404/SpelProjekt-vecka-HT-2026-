//using UnityEngine;

//public class LightController : MonoBehaviour //Alex B.T
//{
//    [SerializeField] private Door door;

//    private void OnMouseDown()
//    {
//        TriggerClick();
//    }

//    public void TriggerClick()
//    {
//        if (door != null)
//        {
//            door.ToggleLight();
//        }
//    }
//}
using UnityEngine;

public class LightController : MonoBehaviour
{
    [SerializeField] private Door Door;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.name);

        Door.ChangeLights();
    }
}

