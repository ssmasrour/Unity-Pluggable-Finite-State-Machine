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
        // Check monitoring transitions
        for (int i = 0; i < fsm.monitoringTransitions.Length; i++)
        {
            if (fsm.monitoringTransitions[i].decision.Check(fsm))
            {
                if (fsm.monitoringTransitions[i].TrueState == null)
                {
                    fsm.ChangeState(fsm.currentState);
                }
                else
                {
                    fsm.ChangeState(fsm.monitoringTransitions[i].TrueState);
                }
            }
            else
            {
                if (fsm.monitoringTransitions[i].FalseState == null)
                {
                    fsm.ChangeState(fsm.currentState);
                } else
                {
                    fsm.ChangeState(fsm.monitoringTransitions[i].FalseState);
                }
            }
        }

        // Check this State transitions
        for (int i = 0; i < transitions.Length; i++)
        {
            if (transitions[i].decision.Check(fsm))
            {
                fsm.ChangeState(transitions[i].TrueState);
            } else
            {
                fsm.ChangeState(transitions[i].FalseState);
            }
        }

        for (int i = 0; i < actions.Length; i++) // Update Action
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
