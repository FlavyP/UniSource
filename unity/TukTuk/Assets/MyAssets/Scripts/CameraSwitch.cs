using UnityEngine;
using System.Collections;

public class CameraSwitch : MonoBehaviour {

    public Camera mainCamera;
    public Camera secondCamera;
	
    void Start ()
    {
        mainCamera.GetComponent<Camera>().enabled = true;
        secondCamera.GetComponent<Camera>().enabled = false;
    }

	void Update () {
	    if (Input.GetKeyDown(KeyCode.C))
        {
            if (mainCamera.GetComponent<Camera>().isActiveAndEnabled) {
                mainCamera.GetComponent<Camera>().enabled = false;
                secondCamera.GetComponent<Camera>().enabled = true;
            } else {
                mainCamera.GetComponent<Camera>().enabled = true;
                secondCamera.GetComponent<Camera>().enabled = false;
            }
        }
	}
}
