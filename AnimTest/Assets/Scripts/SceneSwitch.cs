using UnityEngine;
using System.Collections;

public class SceneSwitch : MonoBehaviour {

    public int sceneIndex;

    void OnTriggerEnter() {
		Application.LoadLevel(sceneIndex);
    }
}
