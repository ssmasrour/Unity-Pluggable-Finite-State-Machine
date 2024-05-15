using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Action/Chase")]
    public class ActionChase : IAction
    {
        public override void Entry(StateController fsm)
        {
            fsm.InactiveAgent(false);
        }

        public override void OnUpdate(StateController fsm)
        {
            fsm.NavAgent.destination = fsm.Player.position;
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
