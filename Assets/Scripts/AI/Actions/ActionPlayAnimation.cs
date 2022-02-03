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

    public override void Execute(StateController fsm)
    {
        
    }

    public override void Exit(StateController fsm)
    {
        
    }

    void PlayAniamtion(StateController controller)
    {
        switch (animationType)
        {
            case AnimationType.BoolType:
                controller.animator.SetBool(parameterName, boolValue);
                break;
            case AnimationType.IntType:
                controller.animator.SetInteger(parameterName, intValue);
                break;
            case AnimationType.FloatType:
                controller.animator.SetFloat(parameterName, floatValue);
                break;
            case AnimationType.TriggerType:
                controller.animator.SetTrigger(parameterName);
                break;
        }
    }
}

public enum AnimationType
{
    BoolType, IntType, FloatType, TriggerType
};
