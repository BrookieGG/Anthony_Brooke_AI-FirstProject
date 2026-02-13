using NodeCanvas.Framework;
using NodeCanvas.Tasks.Actions;
using ParadoxNotion.Design;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class IsCloseCT : ConditionTask {

		private GameObject[] targets;

		public BBParameter<float> detectionRadius = 5f;

		public BBParameter<string> targetTag;

		public bool storeNearest = false;
		public BBParameter<GameObject> nearestTarget;


		//Use for initialization. This is called only once in the lifetime of the task.
		//Return null if init was successfull. Return an error string otherwise
		protected override string OnInit(){

			targets = GameObject.FindGameObjectsWithTag(targetTag.value);

			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

            foreach (GameObject target in targets)
			{
                float distance = Vector3.Distance(agent.transform.position, target.transform.position);

                if (distance <= detectionRadius.value)
                {
                    Blackboard otherBlackboard = agent.GetComponent<Blackboard>(); //gets blackboard
                    otherBlackboard.SetVariableValue(nearestTarget.name, target); //sets the variable in the blackboard to the new value
                    return true;
                }

              
            }
			return false;
		}
	}
}