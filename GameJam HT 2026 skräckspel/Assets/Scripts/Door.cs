using UnityEngine; //Alex B.T

public class Door : MonoBehaviour
{
    [Header("Lights & Power")]
    [SerializeField] private GameObject doorLight;
    [SerializeField] private PowerSystem power;

    [Header("Door Movement Settings")]
    [SerializeField] private float moveDistanceY = 4f; // Hur långt dörren ska åka upp/ned
    [SerializeField] private float doorSpeed = 5f;

    public bool IsOpen = true;
    public bool IsLightOn = false;

    private Vector3 openPos;
    private Vector3 closePos;

    void Start()
    {
        // 1. Sparar dörrens exakta startposition automatiskt från scenen
        openPos = transform.localPosition;

        // 2. Beräknar stängd position baserat på Y-skiftet
        closePos = new Vector3(openPos.x, openPos.y - moveDistanceY, openPos.z);

        // Släck lampan från start
        if (doorLight != null)
            doorLight.SetActive(false);
    }

    void Update()
    {
        // Om strömmen tar slut: Öppna dörren och släck lampan
        if (power != null && power.Power <= 0)
        {
            if (!IsOpen)
            {
                IsOpen = true;
                power.SystemsOn = Mathf.Max(0, power.SystemsOn - 1);
            }

            if (IsLightOn)
            {
                IsLightOn = false;
                if (doorLight != null) doorLight.SetActive(false);
                power.SystemsOn = Mathf.Max(0, power.SystemsOn - 1);
            }
        }

        // Välj målposition beroende på om dörren ska vara öppen eller stängd
        Vector3 targetPos = IsOpen ? openPos : closePos;

        // Flytta dörren stabilt mot målpositionen utan fysik eller flyttalsproblem
        transform.localPosition = Vector3.MoveTowards(transform.localPosition, targetPos, doorSpeed * Time.deltaTime);
    }

    public void ToggleDoor()
    {
        if (power != null && power.Power <= 0) return;

        IsOpen = !IsOpen;

        if (power != null)
        {
            if (!IsOpen)
                power.SystemsOn++;
            else
                power.SystemsOn = Mathf.Max(0, power.SystemsOn - 1);
        }
    }

    public void ToggleLight()
    {
        if (power != null && power.Power <= 0) return;

        IsLightOn = !IsLightOn;

        if (doorLight != null)
            doorLight.SetActive(IsLightOn);

        if (power != null)
        {
            if (IsLightOn)
                power.SystemsOn++;
            else
                power.SystemsOn = Mathf.Max(0, power.SystemsOn - 1);
        }
    }
}