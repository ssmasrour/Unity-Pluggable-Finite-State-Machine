using UnityEngine;

[CreateAssetMenu(menuName = "AI/Action/Play Animation Clip")]
public class ActionPlayAnimation : IAction {
    
    [SerializeField] string parameterName;
    [SerializeField] AnimationType animationType;
    [Space]
    [SerializeField] bool boolValue;
    [SerializeField] int intValue;
    [SerializeField] int floatValue;

    public override void Entry(StateController fsm)
    {
        PlayAniamtion(fsm);
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
        switch (animationType)
        {
            case AnimationType.BoolType:
                controller.Animator.SetBool(parameterName, boolValue);
                break;
            case AnimationType.IntType:
                controller.Animator.SetInteger(parameterName, intValue);
                break;
            case AnimationType.FloatType:
                controller.Animator.SetFloat(parameterName, floatValue);
                break;
            case AnimationType.TriggerType:
                controller.Animator.SetTrigger(parameterName);
                break;
        }
    }
}

public enum AnimationType
{
    BoolType, IntType, FloatType, TriggerType
};
