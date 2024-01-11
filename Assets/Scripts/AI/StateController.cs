using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController : MonoBehaviour
{
    #region Fields and Variable
    [Space]
    public NavMeshAgent NavAgent;
    public Animator Animator;
    // Optional
    public List<Transform> wayPoints;

    [Space]
    [SerializeField]
    private State _startState;

    private State _previousState;
    private State _currentState;
    private float _stateStartTime;
    #endregion


    void Start()
    {
        ChangeState(_startState);
    }

    private void LateUpdate()
    {
        _currentState.OnLateUpdate(this);
    }

    void Update()
    {
        _currentState.OnUpdate(this);
    }

    private void FixedUpdate()
    {
        _currentState.OnFixedUpdate(this);
    }

    public void AIActivator(bool isStopped)
    {
        if (NavAgent.isStopped != isStopped)
        {
            NavAgent.isStopped = isStopped;
        }
    }

    public void ChangeState(State newState)
    {
        if (_currentState == newState) return;

        _currentState?.Exit(this);
        _previousState = _currentState;
        _currentState = newState;
        _currentState.Entry(this);

        _stateStartTime = Time.time;
    }

    public float StateTimer()
    {
        return Time.time - _stateStartTime;
    }

    #region Optional Methods
    public Transform GetRandomWayPoint()
    {
        int i = Random.Range(0, wayPoints.Count - 1);
        return wayPoints[i];
    }
    #endregion
}
