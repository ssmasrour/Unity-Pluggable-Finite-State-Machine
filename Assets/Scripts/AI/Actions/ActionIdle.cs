using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Idle")]
public class ActionIdle : IAction
{
    public override void Entry(StateController fsm)
    {
        fsm.AIActivator(false);
    }

    public override void OnUpdate(StateController fsm)
    {
        fsm.AIActivator(true);
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
