using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    #region Fields and Variable
    public State startState;
    [Space]
    public State previousState;
    public State currentState;

    [Space]
    public NavMeshAgent agent;
    public Animator animator;

    public List<Transform> wayPoints;

    float stateStartTime;
    #endregion


    void Start()
    {
        ChangeState(startState);
    }

    void Update()
    {
        currentState.Execute(this);
    }

    public void AIActivator(bool isStopped)
    {
        if (agent.isStopped != isStopped)
        {
            agent.isStopped = isStopped;
        }
    }

    public void ChangeState(State newState)
    {
        if (currentState == newState) return;

        currentState?.Exit(this);
        previousState = currentState;
        currentState = newState;
        currentState.Entry(this);

        stateStartTime = Time.time;
    }

    public float StateTimer()
    {
        return Time.time - stateStartTime;
    }

    #region Optional Methods
    public Transform GetRandomWayPoint()
    {
        int i = Random.Range(0, wayPoints.Count - 1);
        return wayPoints[i];
    }
    #endregion
}
