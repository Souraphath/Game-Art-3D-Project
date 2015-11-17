using UnityEngine;
using System.Collections;

public class CameraAutoMove : MonoBehaviour {
	public float cameraSpeed;

	// Update is called once per frame
	void Update () {
		transform.Translate (Vector3.right * cameraSpeed * Time.deltaTime);
	}
}