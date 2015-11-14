using UnityEngine;
using System.Collections;

public class ZerosSlash : MonoBehaviour {
	private Animator anim;
	public Rigidbody obj;
	public Transform shotspawn;
	bool attacking = false;
	float attackTimer =0;
	float attackCD=0.4f;
	public bool canMove=false;
	public bool sword=false;
	public ZerosShoot z;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		StartCoroutine (StartDelay());
		z.GetComponent<ZerosShoot> ();
	}
	IEnumerator StartDelay(){
		yield return new WaitForSeconds (2f);
		canMove = true;

	}
	// Update is called once per frame
	void Update () {
		if (canMove == true) {
			if (Input.GetButton ("Fire1") && !attacking && z.gun==false) {
				sword=true;
				attacking = true;
				attackTimer = attackCD;
				Rigidbody clone = Instantiate (obj, shotspawn.position, shotspawn.rotation) as Rigidbody;
				anim.SetBool ("Slash", true);
			}
			if (attacking) {
				if (attackTimer > 0) {
					attackTimer -= Time.deltaTime;
				} else {
					attacking = false;
				}
			}
			if (Input.GetButtonUp ("Fire1")){
				sword=false;
				anim.SetBool ("Slash", false);
			}
		}
		
	}
}
