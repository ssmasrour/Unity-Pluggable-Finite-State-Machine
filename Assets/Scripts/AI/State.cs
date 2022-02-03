using UnityEngine;

[CreateAssetMenu(menuName ="AI/State")]
public class State : ScriptableObject
{
    public IAction[] actions;
    public Transition[] transitions;


    public void Entry(StateController fsm)
    {
        for (int i = 0; i < actions.Length; i++) // Update Action
        {
            actions[i].Entry(fsm);
        }
    }

    public  void Execute(StateController fsm) 
    {
        // Check this State transitions
        for (int i = 0; i < transitions.Length; i++)
        {
            bool decisionResult = transitions[i].decision.Check(fsm);

            if (decisionResult)
            {
                fsm.ChangeState(transitions[i].TrueState);
            } else
            {
                fsm.ChangeState(transitions[i].FalseState);
            }
        }

        for (int i = 0; i < actions.Length; i++)
        {
            actions[i].Execute(fsm);
        }
    }

    public void Exit(StateController fsm)
    {
        for (int i = 0; i < actions.Length; i++) // Update Action
        {
            actions[i].Exit(fsm);
        }
    }
}
