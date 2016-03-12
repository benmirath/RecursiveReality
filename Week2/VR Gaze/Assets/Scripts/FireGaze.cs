using UnityEngine;
// using UnityEngine.VR;

public class FireGaze : MonoBehaviour, IGazable {

	[SerializeField] ParticleSystem[] particles;
	[SerializeField] LayerMask fireLayer;
	[SerializeField] AudioSource fireSound;
	float rayRadius = 1f;
	
	bool hit = false;
	bool lastHit = false;
	
	[SerializeField] Light myLight;
	[SerializeField] Color lightCol1;
	[SerializeField] Color lightCol2;
	
	float lightRange1 = 20;
	float lightRange2 = 25;
	
	float lightTimer;
	bool increasing;
	
	float intensityTimer = 0;
	// Update is called once per frame
	
	void Awake () {
		// for (int i = 0; i < particles.Length; i++) {

		// 	if (particles[i].isPlaying) {
		// 		particles[i].Stop ();
		// 	}
					
		// }	
		// myLight.intensity = 0;			
		// fireSound.volume = 0;
	}
	
	public float delay {
		get { return 3; }
	} 
	float fireLevel = 0;
	float fireIncrement = 0.25f;
	bool gazing = false;
	public void TriggerEffect () {
		gazing = true;
		
	}
	public void CancelEffect () {
		gazing = false;
	}
	
	public ParticleSystem[] fireParticles;
	float fireSizeMin1 = 0.25f;
	float fireSizeMax1 = 1;
	
	float fireSizeMin2 = 5;
	float fireSizeMax2 = 8;
	void Update () {
		float adjust = gazing ? fireLevel + (fireIncrement * Time.deltaTime) : fireLevel - (fireIncrement * Time.deltaTime);
		fireLevel = Mathf.Clamp (adjust, 0, 1);
		
		for (int i = 0; i < fireParticles.Length; i++) {
			// fireParticles[i].startSize 
		}
		
		myLight.range = Mathf.Lerp (lightRange1, lightRange2, lightTimer / 2);
		myLight.color = Color.Lerp (lightCol1, lightCol2, lightTimer / 2);
	}
}
