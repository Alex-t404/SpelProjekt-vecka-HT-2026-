using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] private GameObject Light;

    [SerializeField] private Vector3 OpenPos;
    [SerializeField] private Vector3 ClosePos;

    [SerializeField] private float DoorSpeed;

    public bool IsOpen;
    public bool IsOn;

    [SerializeField] private PowerSystem Power;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = OpenPos;
        IsOpen = true;

        ChangeLights();
    }

    // Update is called once per frame
    void Update()
    {
        if (Power.Power > 0)
        {
            if (IsOpen)
            {
                if (transform.position != OpenPos)
                {
                    if (Vector3.Distance(transform.position, OpenPos) <= 0.5f)
                    {
                        transform.position = OpenPos;
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, OpenPos, DoorSpeed * Time.deltaTime);
                    }
                }
            }
            else
            {
                if (transform.position != ClosePos)
                {
                    if (Vector3.Distance(transform.position, ClosePos) <= 0.5f)
                    {
                        transform.position = ClosePos;
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, ClosePos, DoorSpeed * Time.deltaTime);
                    }
                }
                if (transform.position != ClosePos)
                {
                    if (Vector3.Distance(transform.position, ClosePos) <= 0.5f)
                    {
                        transform.position = ClosePos;
                    }
                    else
                    {
                        transform.position = Vector3.Lerp(transform.position, ClosePos, DoorSpeed * Time.deltaTime);
                    }
                }
            }
        }
        else
        {

            if (transform.position != OpenPos)
            {
                if (Vector3.Distance(transform.position, OpenPos) <= 0.5f)
                {
                    transform.position = OpenPos;
                }
                else
                {
                    transform.position = Vector3.Lerp(transform.position, OpenPos, DoorSpeed * Time.deltaTime);
                }
            }

            IsOn = true;
            ChangeLights();
        }
    }


    public void ChangeLights()
    {
        IsOn = !IsOn;

        if (IsOn)
        {
            Light.SetActive(true);
            Power.SystemsOn += 1;
        }
        else
        {
            Light.SetActive(false);
            Power.SystemsOn -= 1;
        }
    }
}