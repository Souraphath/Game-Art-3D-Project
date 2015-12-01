using UnityEngine;
using System.Collections;

public class Crono : MonoBehaviour {
	GameObject cameraObj;
	CameraScript cameraScript;
	Animator anim;
	public int Dmg;
	public Collider Side;
	public Collider front;
	public PatrolScript patrol;
	public Health hel;
	public float AtkRate;
	public float NextAtkRate;
	bool in2DMode;
	bool inrange;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		cameraScript = cameraObj.GetComponent<CameraScript>();
	}
	// Update is called once per frame
	void Update () {
		in2DMode = cameraScript.in2DMode;
		transform.rotation = Quaternion.Euler (0, cameraObj.GetComponent<CameraScript> ().curYRot, 0);
		if (inrange&&Time.time>NextAtkRate) {
			NextAtkRate=Time.time+AtkRate;
			anim.SetBool ("Slash", true);
			if(!in2DMode&&Side.tag=="Player")
				anim.SetLayerWeight(1,0);
			if(!in2DMode&&front.tag=="Player")
				anim.SetLayerWeight(1,100);
			patrol.distance=0;
			hel.TakeDamage(Dmg);
		}
	}
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			inrange = true;
			Vector3 temp= new Vector3(-4,4,4);
			transform.localScale=temp;
		}
	}
	void OnTriggerExit(Collider other){
		if (other.tag == "Player") {
			inrange = false;
			anim.SetBool("Slash",false);
			patrol.distance=2;
			Vector3 temp= new Vector3(4,4,4);
			transform.localScale=temp;
		}
	}
	void LateUpdate(){
		if (in2DMode) {
			anim.SetLayerWeight (1, 0);
			Vector3 curPos = transform.position;
			Vector3 newPos = curPos - new Vector3 (0, 0, 7 + curPos.z);
			transform.position = newPos;
		} else if (!inrange){
			anim.SetLayerWeight(1,100);
		}
	}
}
