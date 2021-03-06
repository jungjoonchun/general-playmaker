// Custom Action by DumbGameDev
// Assistance by Jean @ Playmaker
// Orginal concept: http://stackoverflow.com/questions/25891033/get-a-random-float-within-range-excluding-sub-range
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Math)]
	[Tooltip("Find random float between two values but excluding a specific range")]
	[HelpUrl("https://www.youtube.com/watch?v=MeTrblMne4E&feature=youtu.be")]
	public class  randomFloatExclusion : FsmStateAction
	{

		[RequiredField]
		[TitleAttribute("Float Min")]
		public FsmFloat minPlaymaker;

		[RequiredField]
		[TitleAttribute("Float Max")]
		public FsmFloat maxPlaymaker;

		[RequiredField]
		[TitleAttribute("Float Min Exclusive")]
		public FsmFloat minExclusivePlaymaker;

		[RequiredField]
		[TitleAttribute("Float Max Exclusive")]
		public FsmFloat maxExclusivePlaymaker;

		[TitleAttribute("Returned Value")]
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat outcome;

		[Tooltip("Repeat every frame")]
		public bool everyFrame;

		private float min;
		private float max;
		private float maxExclusive;
		private float minExclusive;

		float result;

		public override void Reset()
		{

			everyFrame = false;
			min = 0;
			max = 0;
			minExclusive = 0;
			maxExclusive = 0;
			outcome = null;

			minPlaymaker = null;
			maxPlaymaker = null;
			minExclusivePlaymaker = null;
			maxExclusivePlaymaker = null;
		}


		public override void OnEnter()
		{

			DoMath();

			if (!everyFrame)
				Finish();
		}


		public override void OnUpdate()
		{
			DoMath();
		}


		void DoMath()
		{
			min = minPlaymaker.Value;
			max = maxPlaymaker.Value;
			minExclusive = minExclusivePlaymaker.Value;
			maxExclusive = maxExclusivePlaymaker.Value;

			var excluded = maxExclusive - minExclusive;
			var newMax = max - excluded;

			result= Random.Range (min, newMax);

			outcome.Value = result > minExclusive ? result + excluded : result;
		}

	}
}