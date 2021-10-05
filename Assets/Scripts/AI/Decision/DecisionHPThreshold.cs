using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "AI/Decision/Health Point Threshold")]
public class DecisionHPThreshold : IDecision
{
    [Tooltip("Make decision according to current health point")]
    public int threshold;

    public override bool Check(StateController fsm)
    {
        return fsm.HP.GetHP() <= Mathf.Abs(threshold);
    }
}
