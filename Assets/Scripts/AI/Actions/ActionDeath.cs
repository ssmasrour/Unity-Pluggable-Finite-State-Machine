using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Death")]
public class ActionDeath : IAction { 
    public override void Entry(StateController fsm)
    {
        Destroy(fsm.gameObject);
    }

    public override void Execute(StateController fsm)
    {
        
    }

    public override void Exit(StateController fsm)
    {
        
    }
}
