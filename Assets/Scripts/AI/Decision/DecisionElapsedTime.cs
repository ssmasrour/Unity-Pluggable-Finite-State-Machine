using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Elapsed Time")]
public class DecisionElapsedTime : IDecision
{
    public float time;
    public override bool Check(StateController fsm)
    {
        return time < fsm.StateTimer(); 
    }
}
