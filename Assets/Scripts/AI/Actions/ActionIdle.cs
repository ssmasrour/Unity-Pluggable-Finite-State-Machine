using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Idle")]
public class ActionIdle : IAction
{
    public override void Entry(StateController fsm)
    {
        fsm.AIActivator(false);
    }

    public override void Execute(StateController fsm)
    {
        fsm.AIActivator(true);
    }

    public override void Exit(StateController fsm)
    {
        
    }
}
