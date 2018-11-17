using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeSceneAnim : StateMachineBehaviour {
    //state紀錄切換的狀態
    //0: 從Main到Choose
    //1: 從Choose到Main
    public int state;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	//override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        if (this.state == 0) { //開始動畫到進入主畫面
            SceneManager.LoadScene("MainScene");
        }
        else if (this.state == 1) { //主畫面到選單
            SceneManager.LoadScene("ChooseChapterScene");
        }
        else if (this.state == 2)
        { //選單回主畫面
            SceneManager.LoadScene("MainScene");
            //animator.GetComponent<LoadingScript>().DoCoroutine();
        }

        
        
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

}
