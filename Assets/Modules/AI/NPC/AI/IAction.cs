using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IAction : ScriptableObject
{
    public abstract void Entry(StateController fsm);
    public abstract void OnLateUpdate(StateController fsm);
    public abstract void OnUpdate(StateController fsm);
    public abstract void OnFixedUpdate(StateController fsm);
    public abstract void Exit(StateController fsm);
}
