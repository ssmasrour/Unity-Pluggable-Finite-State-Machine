using UnityEngine;

public abstract class IDecision : ScriptableObject
{
    public abstract bool Check(StateController fsm);
}
