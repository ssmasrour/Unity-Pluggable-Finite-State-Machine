using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Wandering")]
public class ActionWandering : IAction
{
    public override void Entry(StateController fsm)
    {
        fsm.AIActivator(true);
    }

    public override void Execute(StateController fsm)
    {
        if (fsm.wayPoints.Count < 1 || !fsm.agent)
        {
            Debug.LogError("Action Wanderin: No way point found");
            return;
        }

        if (fsm.agent.isStopped)
        {
            fsm.agent.isStopped = false;
        }

        if (fsm.agent.destination == null || fsm.agent.remainingDistance <= fsm.agent.stoppingDistance)
        {
            fsm.agent.destination = fsm.GetRandomWayPoint().position;
        }
    }

    public override void Exit(StateController fsm)
    {
        
    }
}
