using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ShiftTimer : MonoBehaviour
{
    [SerializeField] private float Timer;
    [SerializeField] private int ShiftEndTime = 6;
    [SerializeField] private string DigitalClock;

    [SerializeField] private float TimeMultiplier = 2f;

    [SerializeField] private TextMeshProUGUI ClockText;

    [SerializeField] private GameObject WinScreen;

    [SerializeField] private bool Won;

    [SerializeField] private AnimatronicSystem[] Animatronics;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DigitalClock = "";
    }

    // Update is called once per frame
    void Update()
    {
        if (!Won)
        {
            Timer += Time.deltaTime * TimeMultiplier;

            var hours = Mathf.FloorToInt(Timer / 60);
            var minutes = Mathf.FloorToInt(Timer - hours * 60);

            if (minutes == 0)
            {
                for (int i = 0; i < Animatronics.Length; i++)
                {
                    Animatronics[i].ChangeAggressionByHour(hours);
                }
            }

            if (hours >= ShiftEndTime)
            {
                WinScreen.SetActive(true);
                Won = true;
            }

            if (hours == 0)
            {
                hours = 12;
            }

            DigitalClock = string.Format("{0:00}:{1:00}", hours, minutes);

            ClockText.text = DigitalClock;
        }

    }
}