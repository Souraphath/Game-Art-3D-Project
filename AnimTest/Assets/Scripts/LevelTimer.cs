using UnityEngine;
using System.Collections;

public class LevelTimer : MonoBehaviour {

	public float startTime;
	float currentTime;
	GUIStyle style;

	void Start(){
		currentTime = startTime;

		style = new GUIStyle ();
		style.normal.textColor = Color.red;
		style.fontSize = 25;
	}

	void OnGUI(){
		GUI.Label (new Rect(new Vector2(15, 15), new Vector2(50, 20)), "Time: " + (int)currentTime, style);
	}
	
	// Update is called once per frame
	void Update () {
		if (currentTime <= 0) {
			Application.LoadLevel(Application.loadedLevel);
		}
		currentTime -= Time.deltaTime;
	}
}
