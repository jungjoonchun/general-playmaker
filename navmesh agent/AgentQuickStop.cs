// Custom Action by DumbGameDev
// www.dumbgamedev.com

using UnityEngine;
using UnityEngine.AI;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.NavMeshAgent)]
	[Tooltip("Quickly stop a navmesh agent and resets the path. The agent will not use deceleration.")]

	public class AgentQuickStop : FsmStateAction
	{
		
		[RequiredField]
		[CheckForComponent(typeof(NavMeshAgent))]
		[Tooltip("Nav agent game object.")]
		public FsmOwnerDefault gameObject;
		private NavMeshAgent agent;
    
		public override void Reset()
		
		{

			gameObject = null;
		}

		public override void OnEnter()
		{

            var go = Fsm.GetOwnerDefaultTarget(gameObject);
            agent = go.GetComponent<NavMeshAgent>();
			
			stopAgent();

        }

		void stopAgent()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}  
			
			if (agent == null)
			{
				return;
			}     
			
			agent.velocity = Vector3.zero;
			agent.ResetPath();

		}
	}
}