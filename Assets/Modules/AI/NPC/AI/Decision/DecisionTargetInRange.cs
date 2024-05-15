using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Decision/TargetInRange")]
    public class DecisionTargetInRange : IDecision
    {
        public float checkingRange;

        public override bool Check(StateController fsm)
        {
            if (Vector3.Distance(fsm.transform.position, fsm.Player.position) < checkingRange)
            {
                return true;
            }

            return false;
        }
    }
}
