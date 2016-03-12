using UnityEngine;
using UnityEngine.VR;
using System.Collections;

public class OculusUtil : MonoBehaviour {

	// Use this for initialization
	void Start () {
		VRSettings.renderScale = 0.5f;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
			InputTracking.Recenter ();
		}
		
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			VRSettings.renderScale = 0.1f;
		} else if (Input.GetKeyDown (KeyCode.Alpha2)) {
			VRSettings.renderScale = 0.2f;
		} else if (Input.GetKeyDown (KeyCode.Alpha3)) {
			VRSettings.renderScale = 0.3f;
		} else if (Input.GetKeyDown (KeyCode.Alpha4)) {
			VRSettings.renderScale = 0.4f;
		} else if (Input.GetKeyDown (KeyCode.Alpha5)) {
			VRSettings.renderScale = 0.5f;
		} else if (Input.GetKeyDown (KeyCode.Alpha6)) {
			VRSettings.renderScale = 0.6f;
		} else if (Input.GetKeyDown (KeyCode.Alpha7)) {
			VRSettings.renderScale = 0.7f;
		} else if (Input.GetKeyDown (KeyCode.Alpha8)) {
			VRSettings.renderScale = 0.8f;
		} else if (Input.GetKeyDown (KeyCode.Alpha9)) {
			VRSettings.renderScale = 0.9f;
		}
	}
}