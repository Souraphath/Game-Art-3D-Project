using UnityEngine;
using System.Collections;

public class HelicopterScript : MonoBehaviour {

	Animator anim;
    GameObject cameraObj;
	CameraScript cameraScript;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
        cameraObj = GameObject.FindGameObjectWithTag("MainCamera");
        cameraScript = cameraObj.GetComponent<CameraScript>();
		anim.SetBool ("is2DMode", false);
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
            anim.SetBool("is2DMode", false);
        }
    }



}
