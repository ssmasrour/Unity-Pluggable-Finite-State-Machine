using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/TargetInRange")]
public class DecisionTargetInRange : IDecision
{
    public float checkingRange;
    public override bool Check(StateController fsm)
    {
        //if (fsm.Vision.GetTaret() && fsm.Vision.GetDistance() <= checkingRange)
        //{
        //  retun true;
        //}

        return false;
    }
}
