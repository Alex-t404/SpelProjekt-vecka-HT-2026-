using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class AnimatronicSystem : MonoBehaviour
{
    [SerializeField] private NavMeshAgent NMA;
    [SerializeField] private GameObject[] Targets;

    [SerializeField] private int CurrentTarget;

    [SerializeField] private float CoolDownTimer;
    [SerializeField] private float CoolDownTime;

    [SerializeField] private int MinChanceToMove = 1;
    [SerializeField] private int MaxChanceToMove = 20;

    [SerializeField] private int TresholdToPass = 3;

    [SerializeField] private int[] AggressionByHour;

    [SerializeField] private int MinAggressionToAdd = 2;
    [SerializeField] private int MaxAggressionToAdd = 5;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (CoolDownTimer <= 0)
        {
            var chanceCheck = Random.Range(MinChanceToMove, MaxChanceToMove);

            if (chanceCheck <= TresholdToPass)
            {
                if (Vector3.Distance(transform.position, Targets[CurrentTarget].transform.position) <= 2.5f)
                {
                    if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsDoor)
                    {
                        if (Targets[CurrentTarget].GetComponent<DestinationPoint>().Door.IsOpen)
                        {
                            CurrentTarget = Targets.Length - 1;
                        }
                        else
                        {
                            CurrentTarget = 1;
                        }
                    }
                    else if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
                    {
                        Debug.Log("Yóu died");
                    }
                    else
                    {
                        CurrentTarget += 1;
                        if (CurrentTarget >= Targets.Length)
                        {
                            CurrentTarget = 0;
                        }
                    }
                }
            }


            CoolDownTimer = CoolDownTime;
        }
        else
        {
            CoolDownTimer -= Time.deltaTime;
        }

        if (Targets[CurrentTarget].GetComponent<DestinationPoint>().IsOffice)
        {
            Debug.Log("Yóu died");
        }

        NMA.destination = Targets[CurrentTarget].transform.position;

    }

    public void ChangeAggressionByHour(int hour)
    {
        if (TresholdToPass < hour)
        {
            TresholdToPass = AggressionByHour[hour];
        }

        TresholdToPass += Random.Range(MinAggressionToAdd, MaxAggressionToAdd);
    }
}
