using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class AnimationPlayingCT : ConditionTask {

        public Animator animator;
        public string stateName;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit()
        {
            animator = agent.GetComponent<Animator>();
            if (animator != null)
            {
                Debug.Log("no animator found");
            }
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
           if (isAnimationPlaying(stateName) == true)
           {
               return true;
           }
           else
           {
               return false;
           }
		}

        private bool isAnimationPlaying(string animationName)
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName(animationName) && animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
	}
}