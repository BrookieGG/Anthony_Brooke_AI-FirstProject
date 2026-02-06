using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class AnimationAT : ActionTask {

		private Animator animator;
		public string animationBool;
        public string prereqState;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			animator = agent.GetComponent<Animator>();
			if (animator != null )
			{
				Debug.Log("no animator found");
			}
			return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			bool check = true;

			while (check)
			{
				if (!isAnimationPlaying(prereqState))
				{
					animator.SetBool(animationBool, true);
					check = false;
                    EndAction(true);
                }
            }
			
			
		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {
			
		}

		//Called when the task is disabled.
		protected override void OnStop() {
            //animator.SetBool(animationBool, false);
        }

		//Called when the task is paused.
		protected override void OnPause() {
			
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