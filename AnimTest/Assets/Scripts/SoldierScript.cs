using UnityEngine;
using System.Collections;

public class SoldierScript : MonoBehaviour {
	
	Animator anim;
	GameObject cameraObj;
	CameraScript cameraScript;
	GameObject player;
	//Transform shotSpawn;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
		//shotSpawn = transform.GetChild (0);
		cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
		cameraScript = cameraObj.GetComponent<CameraScript>();
		player = GameObject.FindGameObjectWithTag ("Player");
		anim.SetBool ("is2DMode", false);
		//anim.SetBool ("isRight", false);
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Euler (0, cameraObj.GetComponent<CameraScript> ().curYRot, 0);
		bool in2DMode = cameraScript.in2DMode;
		
		if (in2DMode)
		{
			Vector3 curPos = transform.position;
			Vector3 newPos = curPos - new Vector3(0, 0, 7 + curPos.z);
			transform.position = newPos;
			anim.SetBool("is2DMode", true);
		}
		else
		{
			/*if(transform.InverseTransformPoint(player.transform.position).x < 0.0){
				//shotSpawn.position = new Vector3(1, 0, 0);
				anim.SetBool ("isRight", true);
			}*/
			anim.SetBool("is2DMode", false);
		}
	}
	
	
	
}
