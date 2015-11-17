using UnityEngine;
using System.Collections;

public class ZerosSlash : MonoBehaviour {
	private Animator anim;
	public Rigidbody obj;
	public Transform shotspawn;
	public Transform shotspawn1;
	public Transform shotspawn2;
	public Transform shotspawn3;
	bool attacking = false;
	float attackTimer =0f;
	float attackCD=0.45f;
	public bool canMove=false;
	public bool sword=false;
	public ZerosShoot z;
	public AudioClip Slash;
	public AudioClip SlashRoll;
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
		if (canMove == true&&anim.GetBool("IsDead")==false) {
			if (Input.GetButton ("Fire1") && Time.time >attackTimer && z.gun==false) {
				Rigidbody clone;
				sword=true;
				attackTimer = Time.time+attackCD;
				if(anim.GetBool("SecondJump")==true){
				SoundManager.instance.PlaySingle1(SlashRoll);
				clone = Instantiate (obj, shotspawn.position, shotspawn.rotation) as Rigidbody;
				clone = Instantiate (obj, shotspawn1.position, shotspawn1.rotation) as Rigidbody;
				clone = Instantiate (obj, shotspawn2.position, shotspawn2.rotation) as Rigidbody;
				clone = Instantiate (obj, shotspawn3.position, shotspawn3.rotation) as Rigidbody;
				}else{
					clone = Instantiate (obj, shotspawn.position, shotspawn.rotation) as Rigidbody;
					SoundManager.instance.PlaySingle1(Slash);
				}
				anim.SetBool ("Slash", true);
			}
		
			if (Input.GetButtonUp ("Fire1")){
				sword=false;
				anim.SetBool ("Slash", false);
			}
		}
		
	}
}
