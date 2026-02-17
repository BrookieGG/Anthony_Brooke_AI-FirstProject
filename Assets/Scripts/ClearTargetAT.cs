using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class ClearTargetAT : ActionTask {

		public BBParameter<GameObject> target;

		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit() {
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

            Blackboard otherBlackboard = agent.GetComponent<Blackboard>(); //gets blackboard
            otherBlackboard.SetVariableValue(target.name, null); //sets the variable in the blackboard to the new value and sets it to null

			EndAction(true);
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}