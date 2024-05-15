using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Action/Play Animation Clip")]
    public class ActionPlayAnimation : IAction
    {

        [SerializeField] string parameterName;
        [SerializeField] AnimationType animationType;
        [Space]
        [SerializeField] bool boolValue;
        [SerializeField] int intValue;
        [SerializeField] int floatValue;

        public override void Entry(StateController fsm)
        {
            //PlayAniamtion(fsm);
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

        void PlayAniamtion(StateController controller)
        {

        }
    }

    public enum AnimationType
    {
        BoolType, IntType, FloatType, TriggerType
    }
}
