using UnityEngine;
using System.Collections;

public class AuroraCoordinator : MonoBehaviour, IGazable {

	public Aurora[] auroras;
	
	public float delay {
		get { return 0; }
	}
	public void TriggerEffect() {
		for (int i = 0; i < auroras.Length; i++) {
			auroras[i].TriggerEffect ();
		}
	}
	public void CancelEffect () {
		for (int i = 0; i < auroras.Length; i++) {
			auroras[i].CancelEffect ();
		}
	}
	
}
