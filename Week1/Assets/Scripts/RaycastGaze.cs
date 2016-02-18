using UnityEngine;
using System.Collections;

public class RaycastGaze : MonoBehaviour {
	
	bool amIBeingLookedAt = false;
	
	// Update is called once per frame
	void Update () {
		Ray ray = new Ray (Camera.main.transform.position, Camera.main.transform.forward);
		RaycastHit rayHitInfo = new RaycastHit ();
		Debug.DrawRay (ray.origin, ray.direction * 1000f, Color.yellow);
		if (Physics.Raycast (ray, out rayHitInfo, 1000f) && rayHitInfo.collider == GetComponent<Collider> ()) {
			// Debug.Log ("HOWDY HOWDY HOWDY");
			transform.Rotate (0, 20f * Time.deltaTime, 0);
			if (!amIBeingLookedAt) {
				OnStartLook ();
				amIBeingLookedAt = true;
			}
		} else {
			if (amIBeingLookedAt) {
				OnStoptLook ();
				amIBeingLookedAt = false;
			}
		}
    }
	
	void OnStartLook () {
		
	}
	void OnStoptLook () {
		
	}
	void OnNotLooking () {
		
	}
	void OnLooking () {	//should happen every update, as long as this object is being looked at
		transform.Rotate (0, 20f * Time.deltaTime, 0);
	}
	
}
