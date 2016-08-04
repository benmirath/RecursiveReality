using UnityEngine;
using System.Collections;

public class ButtonDemo : MonoBehaviour {

	public Transform photoSphere;

	public void Rotate (float degrees) {
		photoSphere.Rotate (0f, degrees, 0f);
	}
}
