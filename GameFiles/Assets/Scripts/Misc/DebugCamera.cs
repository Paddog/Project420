using UnityEngine;
using System.Collections;

public class DebugCamera : MonoBehaviour {
    public float cameraSpeed = 5;
    public static bool debugEnabled = false;

    private Vector3 centeredCameraPos;
	// Use this for initialization
	void Start () {
        centeredCameraPos = Camera.main.transform.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyUp(KeyCode.P)) {
            debugEnabled = !debugEnabled;
            if(debugEnabled == false) {
                Camera.main.transform.localPosition = centeredCameraPos;
            }
        }

        if(debugEnabled) {
            Camera.main.orthographicSize += -Input.GetAxis("Mouse ScrollWheel");
            float debugCam_x = Input.GetAxisRaw("Horizontal");
            float debugCam_y = Input.GetAxisRaw("Vertical");


            Vector2 movVertical = transform.up * debugCam_y;
            Vector2 movHorizontal = transform.right * debugCam_x;

            Vector2 velocity = (movVertical + movHorizontal).normalized * cameraSpeed;
            this.transform.Translate(velocity);
            
        }
        
	}
}
