using UnityEngine;
using System.Collections;

public class BookRotater : MonoBehaviour {
	Camera cam;
	float padding = 270;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.eulerAngles = new Vector3 (0, padding + cam.transform.eulerAngles.y);
	}
}
