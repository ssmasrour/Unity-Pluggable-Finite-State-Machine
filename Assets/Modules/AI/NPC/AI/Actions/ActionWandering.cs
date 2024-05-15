using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Action/Wandering")]
    public class ActionWandering : IAction
    {
        public override void Entry(StateController fsm)
        {
            fsm.InactiveAgent(true);
        }

        public override void OnUpdate(StateController fsm)
        {
            if (fsm.wayPoints.Count < 1 || !fsm.NavAgent)
            {
                Debug.LogError("Action Wanderin: No way point found");
                return;
            }

            if (fsm.NavAgent.isStopped)
            {
                fsm.NavAgent.isStopped = false;
            }

            if (fsm.NavAgent.destination == null || fsm.NavAgent.remainingDistance <= fsm.NavAgent.stoppingDistance)
            {
                fsm.NavAgent.destination = fsm.GetRandomWayPoint().position;
            }
        }


        public override void OnLateUpdate(StateController fsm)
        {
            // write your code here
        }

        public override void OnFixedUpdate(StateController fsm)
        {
            // write your code here
        }

        public override void Exit(StateController fsm)
        {

        }


    }
}
