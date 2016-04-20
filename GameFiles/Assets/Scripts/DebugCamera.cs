using UnityEngine;
using System.Collections;

public class DebugCamera : MonoBehaviour {

    private bool debugEnabled = false;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.P)) {
            debugEnabled = !debugEnabled;
        }

        if(debugEnabled) {
            Camera.main.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");
        }
        
	}
}
