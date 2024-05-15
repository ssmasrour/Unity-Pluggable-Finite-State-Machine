using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Decision/Elapsed Time")]
    public class DecisionElapsedTime : IDecision
    {
        public float time;
        public override bool Check(StateController fsm)
        {
            return time < fsm.StateTimer();
        }
    }
}
