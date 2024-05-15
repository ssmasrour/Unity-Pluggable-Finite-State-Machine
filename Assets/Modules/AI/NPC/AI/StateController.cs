using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Sahab.AI
{
    public class StateController : MonoBehaviour
    {
        public Transform Player { get; private set; }

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
            Player = GameObject.FindGameObjectWithTag("Player").transform;

            Debug.Assert(Player != null);
            Debug.Assert(Animator != null);
            Debug.Assert(NavAgent != null);
            Debug.Assert(_startState != null);

            ChangeState(_startState);
        }

        private void LateUpdate()
        {
            _currentState.OnLateUpdate(this);
        }

        void Update()
        {
            _currentState.OnUpdate(this);
            Animator.SetFloat("Move", Mathf.Clamp(NavAgent.velocity.sqrMagnitude, 0, 1));
        }

        private void FixedUpdate()
        {
            _currentState.OnFixedUpdate(this);
        }

        public void InactiveAgent(bool isStopped)
        {
            if (isStopped)
            {
                NavAgent.destination = transform.position;
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
}
