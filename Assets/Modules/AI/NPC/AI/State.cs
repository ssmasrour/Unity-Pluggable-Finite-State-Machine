using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/State")]
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

        public void OnLateUpdate(StateController fsm)
        {
            // Check this State transitions
            CheckTransition(fsm);

            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].OnLateUpdate(fsm);
            }
        }

        public void OnUpdate(StateController fsm)
        {
            // Check this State transitions
            CheckTransition(fsm);

            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].OnUpdate(fsm);
            }
        }


        public void OnFixedUpdate(StateController fsm)
        {
            CheckTransition(fsm);

            for (int i = 0; i < actions.Length; i++)
            {
                actions[i].OnFixedUpdate(fsm);
            }
        }

        public void Exit(StateController fsm)
        {
            for (int i = 0; i < actions.Length; i++) // Update Action
            {
                actions[i].Exit(fsm);
            }
        }

        private void CheckTransition(StateController fsm)
        {
            for (int i = 0; i < transitions.Length; i++)
            {
                bool decisionResult = transitions[i].decision.Check(fsm);

                if (decisionResult)
                {
                    fsm.ChangeState(transitions[i].TrueState);
                }
                else
                {
                    fsm.ChangeState(transitions[i].FalseState);
                }
            }
        }

    }
}
