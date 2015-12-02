using UnityEngine;
using System.Collections;

public class ScoreScript : MonoBehaviour {

	public static int PLAYER_SCORE;
	GUIStyle style;

	void Start () {
		PLAYER_SCORE = 0;

		style = new GUIStyle();
		style.normal.textColor = Color.red;
		style.fontSize = 25;
	}
	
	void OnGUI(){
		GUI.Label (new Rect(new Vector2(150, 15), new Vector2(50, 20)), "Score: " + PLAYER_SCORE, style);
	}
}
