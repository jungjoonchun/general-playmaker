using System;
using UnityEngine;
using UnityEngine.AI;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.NavMeshAgent)]
	[Tooltip("Enable or disable navmesh agent component")]

	public class  enableNavmeshAgent : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(NavMeshAgent))]
		[Tooltip("Gameobject containing the navmesh agent.")]
		public FsmOwnerDefault gameObject;
		
		[Tooltip("Set to true to enable.")]
		public FsmBool enable;

		private NavMeshAgent navmeshagent;

		public override void Reset()
		{

			gameObject = null;
			enable = true;
		}

		public override void OnEnter()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			navmeshagent = go.GetComponent<NavMeshAgent>();

			doNavMeshChange();
			Finish();

		}

		void doNavMeshChange()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
			
			navmeshagent.enabled = enable.Value;

		}

	}
}