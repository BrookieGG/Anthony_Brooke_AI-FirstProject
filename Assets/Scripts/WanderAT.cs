using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine.AI;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class WanderAT : ActionTask {

		public BBParameter<float> wanderDist = 10f;
		public BBParameter<float> wanderRadius = 5f;
		public BBParameter<float> sampleMaxDist = 2f;
		
		private NavMeshAgent navAgent;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {

			navAgent = agent.GetComponent<NavMeshAgent>();
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			if (navAgent.remainingDistance <= navAgent.stoppingDistance)
			{
				Vector3 origin = agent.transform.localPosition;
				Vector3 facingDirection = agent.transform.forward;

				for (int i = 0; i < 20; i++)
				{
					Vector3 randomOffset = Random.insideUnitCircle * wanderRadius.value;

					Vector3 destination = origin + facingDirection + randomOffset;

					if (NavMesh.SamplePosition(destination, out NavMeshHit hit, sampleMaxDist.value, NavMesh.AllAreas))
					{
						navAgent.SetDestination(destination);
						return;
					}
				}
			}
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}