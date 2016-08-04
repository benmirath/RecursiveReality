using UnityEngine;
using System.Collections;

public class posAdjust : MonoBehaviour {	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z - 0.1f);
		} else if (Input.GetKeyDown (KeyCode.RightArrow)) {
			transform.localPosition = new Vector3 (transform.localPosition.x, transform.localPosition.y, transform.localPosition.z + 0.1f);
		}
	}
}
