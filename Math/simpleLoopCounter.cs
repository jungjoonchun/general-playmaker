// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Custom")]
	[Tooltip("Count number of loops on a state.")]
	public class simpleLoopCounter : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Enter the number of times you want this action to loop")]
		[TitleAttribute("Max Loop Count")]
		public FsmInt maxCount;
		[Tooltip("Can start loop at number other than 0")]
		[TitleAttribute("Current Loop Count")]
		public FsmInt currentCount;
		[Tooltip("Can change the loop to count more than 1 per loop")]
		[TitleAttribute("Add per Loop Count")]
		public FsmInt loopAdd;
		[Tooltip("Once the loop count max is reached, this event will fire")]
		[TitleAttribute("Loop Reached Event")]
		public FsmEvent equal;
		[Tooltip("Loop has not yet reached max value event")]
		[TitleAttribute("Loop Continue Event")]
		public FsmEvent lessThan;
		[Tooltip("Loop number has been exceeded. Maybe somethig has gone wrong.")]
		[TitleAttribute("Loop Exceeded Event")]
		public FsmEvent greaterThan;

		public bool everyFrame;

		public override void Reset()
		{
			maxCount = 0;
			currentCount = 0;
			loopAdd = 1;
			equal = null;
			lessThan = null;
			greaterThan = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{

			currentCount.Value += loopAdd.Value;

			if (maxCount.Value == currentCount.Value)
			{
				Fsm.Event(equal);
				return;
			}

			if (maxCount.Value > currentCount.Value)
			{
				Fsm.Event(lessThan);
				return;
			}

			if (maxCount.Value < currentCount.Value)
			{
				Fsm.Event(greaterThan);
			}

		}

		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(equal) &&
				FsmEvent.IsNullOrEmpty(lessThan) &&
				FsmEvent.IsNullOrEmpty(greaterThan))
				return "This action requires an event!";
			return "";
		}
	}
}