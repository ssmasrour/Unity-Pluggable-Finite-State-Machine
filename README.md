# Modular Finite State Machine Unity (C#)

A finite-state machine is **a model used to represent and control execution flow**. It is perfect for implementing AI in games and producing great results without a complex code.
In this FSM modularity and Pluggablity managed with Scriptable Object.
Open-closed and Single responsibility is in high periority.

### Use Cases 
 - None-Player Character (NPC) AI behaviours, Animations
 - Dynamic (Self-adjusting)) game difficulity
 - Gameplay objects in specific states (Pause, Continue, Game over, Restart, etc)

## Simplicity
**Blank State as a code sluts** 
No need to Develope every state from scratch. just focuse on your custom actions and conditions that make an State to be switched with another State.
**Reusable and Pluggable Code** 
Wrap all your codes in **ScriptableObject** , and let even non-coders build their own custom AI with Drag&Drop

## Usage
### Action
Action is a script that execute within main body of States, Inheritate from `IAction`

	public abstract class IAction : ScriptableObject
	{
		public abstract void Entry(StateController fsm);
		public abstract void Execute(StateController fsm);
		public abstract void Exit(StateController fsm);
	}

**Sample of a custom action**
Character wandering around the scene randomly between a list of path points

		[CreateAssetmenu]
	    public class PatrolAction : IAction
		{
		    public override void Entry(StateController fsm)
		    {
		        fsm.AIActivator(true);
		    }

		    public override void Execute(StateController fsm)
		    {
                if (fsm.wayPoints.Count < 1 || !fsm.agent) return;
                if (fsm.agent.destination == null || fsm.agent.remainingDistance <= 1.0f)
		        {
		            fsm.agent.destination = fsm.GetRandomWayPoint().position;
		        }
		    }

		    public override void Exit(StateController fsm)
		    {
		        fsm.AIActivator(false);
		    }
	}
### Decision
Decision return a Boolean value in a certain condition, according to True/False result a transition occurs from one state to another.

    public abstract class IDecision : ScriptableObject
	{
	    public abstract bool Check(StateController fsm);
	}
**Sample of a custom decision**
Check if current Health Point Value is less than specified `threshold`

    [CreateAssetMenu]
	public class HPThresholdDecision : IDecision
	{
		    public int threshold;
		    public override bool Check(StateController fsm)
		    {
		        return fsm.HP.GetHP() <= Mathf.Abs(threshold);
		    }
	}

## Setup
