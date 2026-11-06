using UnityEngine; //Alex B.T
using UnityEngine.InputSystem; // Krävs för det nya Input System

public class CameraSystem : MonoBehaviour
{
    [SerializeField] private GameObject[] Cameras;
    [SerializeField] private int CurrentCam;

    // Bytt från KeyCode till Key för det nya Input System
    [SerializeField] private Key OpenCamerasKey = Key.Space;

    //Kom ihåg att kolla hur många kameror är i kamera listan när du fixar Game manager. Listan med kamerorna är ovanför noll. 
    [SerializeField] private bool CamerasOpen;
    [SerializeField] private GameObject MainCamera;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float CoolDownTime = 0.5f;

    [SerializeField] private GameObject CameraSystemUI;
    [SerializeField] private PowerSystem Power;

    void Start()
    {
        for (int i = 0; i < Cameras.Length; i++)
        {
            if (Cameras[i] != null)
                Cameras[i].SetActive(false);
        }
        if (CameraSystemUI != null)
            CameraSystemUI.SetActive(false);

        if (MainCamera != null)
            MainCamera.SetActive(true);
    }

    void Update()
    {
        // Se till att tangentbordet är anslutet
        if (Keyboard.current == null) return;

        if (Power != null && Power.Power > 0f)
        {
            // Kontrollerar om knappen trycktes ned denna bildruta
            if (Keyboard.current[OpenCamerasKey].wasPressedThisFrame)
            {
                CamerasOpen = !CamerasOpen;
                if (CamerasOpen)
                {
                    Power.SystemsOn += 1;
                }
                else
                {
                    Power.SystemsOn -= 1;
                }
                ShowCamera();
            }

            if (CoolDownTimer <= 0)
            {
                // Läser av A/D eller Vänster/Höger piltangent
                float horizontalInput = 0f;
                if (Keyboard.current.dKey.isPressed || Keyboard.current.rightArrowKey.isPressed)
                {
                    horizontalInput = 1f;
                }
                else if (Keyboard.current.aKey.isPressed || Keyboard.current.leftArrowKey.isPressed)
                {
                    horizontalInput = -1f;
                }

                if (horizontalInput > 0)
                {
                    Cameras[CurrentCam].SetActive(false);
                    CurrentCam = CurrentCam + 1;
                    if (CurrentCam >= Cameras.Length)
                    {
                        CurrentCam = 0;
                    }
                    GoToCamera(CurrentCam);
                    CoolDownTimer = CoolDownTime;
                }
                else if (horizontalInput < 0)
                {
                    Cameras[CurrentCam].SetActive(false);
                    CurrentCam = CurrentCam - 1;
                    if (CurrentCam < 0)
                    {
                        CurrentCam = Cameras.Length - 1;
                    }
                    GoToCamera(CurrentCam);
                    CoolDownTimer = CoolDownTime;
                }
            }
            else
            {
                CoolDownTimer -= Time.deltaTime;
            }
        }
        else
        {
            CamerasOpen = false;
            ShowCamera();
        }
    }

    private void ShowCamera()
    {
        if (CamerasOpen)
        {
            if (Cameras[CurrentCam] != null)
                Cameras[CurrentCam].SetActive(true);

            if (MainCamera != null)
                MainCamera.SetActive(false);

            if (CameraSystemUI != null)
                CameraSystemUI.SetActive(true);
        }
        else
        {
            if (Cameras[CurrentCam] != null)
                Cameras[CurrentCam].SetActive(false);

            if (MainCamera != null)
                MainCamera.SetActive(true);

            if (CameraSystemUI != null)
                CameraSystemUI.SetActive(false);
        }
    }

    public void GoToCamera(int Progression)
    {
        if (Cameras[CurrentCam] != null)
            Cameras[CurrentCam].SetActive(false);

        CurrentCam = Progression;
        ShowCamera();
    }
}