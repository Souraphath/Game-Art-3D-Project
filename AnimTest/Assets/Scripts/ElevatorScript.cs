using UnityEngine;
using System.Collections;

public class ElevatorScript : MonoBehaviour
{
	Animator animator;
	
	void Awake(){
		animator = GetComponent<Animator> ();
	}
	
	void OnTriggerEnter(){
		animator.SetTrigger ("isPlayer");
	}
}