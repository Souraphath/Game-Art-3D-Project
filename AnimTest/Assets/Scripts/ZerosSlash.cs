using UnityEngine;
using System.Collections;

public class ZerosSlash : MonoBehaviour {
	private Animator anim;
	public Rigidbody obj;
	public Transform shotspawn;
	bool attacking = false;
	float attackTimer =0;
	float attackCD=0.4f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
		Rigidbody clone;
		if (Input.GetButton ("Fire1") && !attacking) {
			attacking=true;
			attackTimer=attackCD;
			clone = Instantiate (obj,shotspawn.position,shotspawn.rotation) as Rigidbody ;
			anim.SetBool ("Slash", true);
		}
		if (attacking) {
			if(attackTimer>0){
				attackTimer-=Time.deltaTime;
			}
			else{
				attacking=false;
			}
		}
		if (Input.GetButtonUp ("Fire1"))
			anim.SetBool ("Slash",false);
		
		
	}
}
