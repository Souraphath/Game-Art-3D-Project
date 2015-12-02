using UnityEngine;
using System.Collections;

public class CameraScriptSwitch : MonoBehaviour {

	public Camera camera1;
	public Camera camera2;

	CameraScript playerCam;
	bool cam1, cam2;

	// Use this for initialization
	void Start () {
		playerCam = camera1.GetComponent<CameraScript> ();
		cam1 = true;
		cam2 = false;
	}
	
	void OnTriggerEnter(Collider other){
		if (other.tag != "Player")
			return;
		if (cam1) {
			camera1.enabled = false;
			camera2.enabled = true;
			cam1 = false;
			cam2 = true;
			if(camera1.gameObject.GetComponent<CameraScript>().in2DMode)
				camera1.gameObject.GetComponent<CameraScript>().switchPerspective();
			playerCam.canShift = false;
		} else if (cam2) {
			camera1.enabled = true;
			camera2.enabled = false;
			cam1 = true;
			cam2 = false;
			playerCam.canShift = true;
		}
	}
}
