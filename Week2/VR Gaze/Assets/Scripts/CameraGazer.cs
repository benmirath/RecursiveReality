using UnityEngine;
using UnityEngine.VR;
using UnityEngine.UI;
using System.Collections;

public class CameraGazer : MonoBehaviour {

	public Image countdownImg;
	IGazable gazeTarget;
	float timer;
	// Use this for initialization
	
	public LayerMask triggerLayer;
	// float rayRadius = 2;
	void Start () {
		timer = 0;
		gazeTarget = null;
		countdownImg.enabled = false;
		countdownImg.fillAmount = 0;
	}
	
	
	
	// Update is called once per frame
	void Update () {	
		bool zooming = Input.GetKey (KeyCode.Space);
		Camera.main.fieldOfView = Mathf.MoveTowards (Camera.main.fieldOfView, (zooming ? 15 : 60), 30 * Time.deltaTime);	
			
		RaycastHit rayHit;
		// bool hit = Physics.SphereCast (Camera.main.transform.position, rayRadius, Camera.main.transform.forward, out rayHit, 200f, triggerLayer);
		
		Vector3 rayOrigin = Camera.main.transform.position;
		Vector3 rayDirection = Camera.main.transform.forward;
		// if we are using VR, we can get more accurate info by reading the tracking info directly
		// (this also fixes a bug in OSX when using Unity's Standard Assets FPSController and MouseLook, where Camera forward is based on mouse)
		// if ( VRSettings.loadedDevice != VRDeviceType.None ) {
		// 	// shoot a ray based on the HMD's reported rotation
		// 	rayDirection = InputTracking.GetLocalRotation(VRNode.CenterEye) * Vector3.forward; 
		// 	// do extra correction pass if Main Camera is parented to something
		// 	if ( Camera.main.transform.parent != null ) { 
		// 		rayDirection = Camera.main.transform.parent.TransformDirection( rayDirection ); 
		// 	}
		// }
		
		bool hit = Physics.Raycast (rayOrigin, rayDirection, out rayHit, 200f, triggerLayer);
		Debug.DrawRay (rayOrigin, rayDirection * 200, Color.red, 0);
		Debug.LogError (rayHit.transform);
		if (hit) {
			Debug.LogError ("hit");
			if (gazeTarget == null) {	//new timer
				timer = 0;
				gazeTarget = rayHit.transform.GetComponent<IGazable> ();
				countdownImg.enabled = true;
				countdownImg.fillAmount = 0;
			}
			
			if (gazeTarget != null) {
				timer += Time.deltaTime;
				countdownImg.fillAmount = Mathf.Lerp (0, 1, timer / gazeTarget.delay);
				if (timer > gazeTarget.delay) {
					countdownImg.fillAmount = 1;
					gazeTarget.TriggerEffect ();	
					
					if (gazeTarget.delay == 0) {
						countdownImg.fillAmount = 0;
					}
				}
			}
		} else if (gazeTarget != null) {
			gazeTarget.CancelEffect ();
			gazeTarget = null;
			countdownImg.enabled = false;
		}
		
			
	}
	
	// void OnDrawGizmos () {
	// 	Vector3 rayOrigin = Camera.main.transform.position;
	// 	Vector3 rayDirection = Camera.main.transform.forward;
	// 	// if we are using VR, we can get more accurate info by reading the tracking info directly
	// 	// (this also fixes a bug in OSX when using Unity's Standard Assets FPSController and MouseLook, where Camera forward is based on mouse)
	// 	if ( VRSettings.loadedDevice != VRDeviceType.None ) {
	// 		// shoot a ray based on the HMD's reported rotation
	// 		rayDirection = InputTracking.GetLocalRotation(VRNode.CenterEye) * Vector3.forward; 
	// 		// do extra correction pass if Main Camera is parented to something
	// 		if ( Camera.main.transform.parent != null ) { 
	// 			rayDirection = Camera.main.transform.parent.TransformDirection( rayDirection ); 
	// 		}
	// 	}
		
	// 	// bool hit = Physics.Raycast (rayOrigin, rayDirection, out rayHit, 200f, triggerLayer);
	// 	Gizmos.color = Color.red;
	// 	Gizmos.DrawRay (rayOrigin, rayDirection * 200);
		
	// }
}