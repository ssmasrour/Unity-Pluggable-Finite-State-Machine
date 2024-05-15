using UnityEngine;

namespace Sahab.AI
{
    [System.Serializable]
    public class Transition
    {
        public IDecision decision;
        public State TrueState;
        public State FalseState;
    }
}
