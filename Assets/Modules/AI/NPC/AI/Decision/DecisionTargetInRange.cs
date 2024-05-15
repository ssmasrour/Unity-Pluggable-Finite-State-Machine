using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Sahab.AI
{
    [CreateAssetMenu(menuName = "AI/Decision/TargetInRange")]
    public class DecisionTargetInRange : IDecision
    {
        public float checkingRange;
        public float viewAngle = 45.0f;
        public LayerMask obstacleMask;

        public override bool Check(StateController fsm)
        {
            if (CanSeePlayer(fsm.transform, fsm.Player))
            {
                return true;
            }

            return false;
        }

    bool CanSeePlayer(Transform me,Transform player)
    {
        Vector3 direction = (player.position - me.position).normalized;
        float distance = Vector3.Distance(me.position, player.position);

        if (distance <= checkingRange)
        {

            if (Vector3.Angle(me.forward, direction) < viewAngle / 2)
            {

                RaycastHit hit;
                if (Physics.Raycast(me.position, direction, out hit, distance, obstacleMask))
                {
                    return false;
                }
                return true;
            }
        }

        // Player not within view radius or angle, or obstructed
        return false;
    }
    }

}
