// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("ActionCategory.Material")]
	[Tooltip("Sets material propery block colors for lerp (animation) between two colors.")]
	public class  setMaterialProperyBlockColor : ComponentAction<Renderer>
	{
		[Tooltip("The GameObject that the material is applied to.")]
		[CheckForComponent(typeof(Renderer))]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[TitleAttribute("Material Color")]
		public FsmColor Color1;

		[Tooltip("Repeat every frame for animation")]
		public bool everyFrame;

		private Renderer _renderer;
		private MaterialPropertyBlock _propBlock;

		public override void Reset()
		{

			gameObject = null;
			Color1 = Color.black;
			everyFrame = false;

		}


		public override void OnEnter()
		{

			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			_renderer = go.GetComponent<Renderer>();

			_propBlock = new MaterialPropertyBlock ();

			DoColorChange();

			if (!everyFrame)
				Finish();
		}


		public override void OnUpdate()
		{
				DoColorChange();
		}


		void DoColorChange()
		{

			_renderer.GetPropertyBlock (_propBlock);
			_propBlock.SetColor ("_Color", Color1.Value);
			_renderer.SetPropertyBlock (_propBlock);

		}

	}
}