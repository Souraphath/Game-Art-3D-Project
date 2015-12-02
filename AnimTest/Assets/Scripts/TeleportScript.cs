using UnityEngine;
using System.Collections;

public class TeleportScript : MonoBehaviour {

	public Transform pairPadLocation;
	public TeleportScript otherScript;
	public Camera switchTo;
	public Camera switchFrom;
	public float teleCooldown;
	public CameraScript mainScript;

	void Update(){
		teleCooldown += Time.deltaTime;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag == "Player") {
			if(otherScript.teleCooldown >= 2){
				Vector3 heightCorrect = new Vector3 (0, 0, 0);
				other.transform.position = pairPadLocation.position + heightCorrect;
				if(switchFrom.tag == "MainCamera") 
					mainScript.canShift = false;
				else
					mainScript.canShift = true;
				switchFrom.enabled = false;
				switchTo.enabled = true;

				teleCooldown = 0;
			}
		}
	}
}
