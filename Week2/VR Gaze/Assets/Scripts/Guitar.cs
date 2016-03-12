using UnityEngine;
using System.Collections;

public class Guitar : MonoBehaviour, IGazable {
	public float delay {
		get {
			return 2;
		}
	}
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	void Update () {
		if (!playing) {
			if (audio.volume > 0) {
				audio.volume = Mathf.MoveTowards (audio.volume, 0, 0.005f * Time.deltaTime);
			} else {
				audio.Stop ();
			}
		} else {
			if (!audio.isPlaying) {
				audio.Play ();
			}
			audio.volume = Mathf.MoveTowards (audio.volume, 0.1f, 0.5f * Time.deltaTime);
		}
	}
	
	AudioSource audio;
	bool playing = false;
	public void TriggerEffect () {
		// if (audio.isPlaying) {
		// 	// audio.Stop ();
		// }
		playing = !playing;
		
	}
	public void CancelEffect () {
		
	}
	
}
