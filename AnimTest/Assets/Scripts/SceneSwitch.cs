using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public string sceneName;

    void OnTriggerEnter(Collider other) {
		if (other.tag == "Player") {
			StartCoroutine (Delay ());
		}
       
    }
	IEnumerator Delay(){
		yield return new WaitForSeconds (1.5f);
		Application.LoadLevel(sceneName);
	}
}
