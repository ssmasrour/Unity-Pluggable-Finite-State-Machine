using UnityEngine;

namespace Sahab.AI
{
    public abstract class IDecision : ScriptableObject
    {
        public abstract bool Check(StateController fsm);
    }
}
