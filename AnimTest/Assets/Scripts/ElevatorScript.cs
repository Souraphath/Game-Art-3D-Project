using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
	Animator animator;
	
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Player")) {
			if(this.animator.GetCurrentAnimatorStateInfo(0).IsName ("Elevator Up Animation")){
				other.transform.parent = transform;
			}
			animator.SetTrigger ("isPlayer");
		}
	}
	
	void OnTriggerExit(Collider other){
		if (other.gameObject.CompareTag ("Player") && !this.animator.IsInTransition(0)) {
			other.transform.parent = null;
		}
	}
}