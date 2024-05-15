using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Action/Idle")]
    public class ActionIdle : IAction
    {
        public override void Entry(StateController fsm)
        {
            fsm.InactiveAgent(true);
        }

        public override void OnUpdate(StateController fsm)
        {

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
