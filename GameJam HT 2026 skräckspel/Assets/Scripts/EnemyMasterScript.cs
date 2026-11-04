using System;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

public class EnemyMasterScript : MonoBehaviour
{
    
    [SerializeField] protected int currentWaypoint;
    [SerializeField] protected int previousWaypoint;
    [SerializeField] protected int wanderWaypoint;
    [SerializeField] protected float fatigue;
    [SerializeField] protected float indecisionMult;
    [SerializeField] protected float frustrationMult;
    [SerializeField] protected float startAggression;
    [SerializeField] protected float aggression;
    [SerializeField] protected float moveTimer = 0;
    [SerializeField] protected float moveInterval;
    [SerializeField] protected float headstart;
    [SerializeField] protected float blockStun;
    [SerializeField] protected bool blocked = false;
    [SerializeField] protected const bool wanderer = true;

    protected virtual void Start()
    {
        
        aggression = startAggression;
    }
    
    // Update is called once per frame
    protected virtual void FixedUpdate()
    {
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveInterval)
        {
            var chanceCheck = UnityEngine.Random.Range(1, 20);
            if (chanceCheck <= aggression)
            {
                if (currentWaypoint == wanderWaypoint)
                {
                    switch (wanderer)
                    {
                        case wanderer:
                            Wander();
                            return;
                    }
                }
                else if (currentWaypoint != wanderWaypoint)
                {
                    switch (currentWaypoint)
                    {
                        case > 10:
                            currentWaypoint = previousWaypoint;
                            previousWaypoint--;
                            moveTimer = 0;
                            break;
                        default:
                            Movement();
                            break;
                    }
                }
            }
            else if (chanceCheck >= aggression && currentWaypoint != wanderWaypoint)
            {
                moveTimer = 0;
            }
        }
        
    }
    protected virtual void ResetAnimatronic()
    {
        var chanceCheck = UnityEngine.Random.Range(1, 3);
        if (chanceCheck <= 3) { currentWaypoint = 1; }
        else { currentWaypoint = 0; }
        moveTimer = 0 - blockStun;
    }
    protected virtual void Movement()
    {
        previousWaypoint++;
        currentWaypoint = currentWaypoint + 1;
        moveTimer = 0;
    }
    protected virtual void Wander()
    {
        
        if (moveTimer >= aggression - fatigue * indecisionMult)
        {
            var chanceCheck = UnityEngine.Random.Range(1, 20);
            if (chanceCheck >= 1 + fatigue && chanceCheck <= 6 - fatigue)
            {
                currentWaypoint = currentWaypoint + 9;
                previousWaypoint++;
                fatigue++;
                aggression = aggression * frustrationMult;
            }
            else if (chanceCheck >= 5 + fatigue && chanceCheck <= 10 - fatigue)
            {
                currentWaypoint = currentWaypoint + 10;
                previousWaypoint++;
                fatigue++;
                aggression = aggression * frustrationMult;
            }
            else { previousWaypoint++;  currentWaypoint = currentWaypoint + 1; fatigue = fatigue / 2; moveTimer = 0; }
        }
    }
}

