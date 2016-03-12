using UnityEngine;
using System.Collections;

public class Aurora : MonoBehaviour, IGazable {

	Material aMaterial;
	float offset;
	public bool reversed;
	
	public Material[] options;
	
	float scaleMin = 12;
	float scaleMax = 40;
	float _initScale; 
	float adjustSpeed = .5f;
	
	public Transform targ;
	
	int dir;
	// Use this for initialization
	void Awake () {
		// _initScale = 1;
		transform.localScale = new Vector3 (0, transform.localScale.y, transform.localScale.z);
		targScale = transform.localScale;
		
		Renderer rend = GetComponent<Renderer> ();
		rend.material = options[Random.Range (0, options.Length)];
		aMaterial = rend.material;
		transform.LookAt (targ, Vector3.forward);
		// aMaterial = this.GetComponent<Renderer>().material;
	}
	
	Vector3 targScale;
	// Update is called once per frame
	void Update () {
		
		// if (viewed) {
			
		// } else {
			
		// }
		transform.localScale = Vector3.MoveTowards (transform.localScale, targScale, adjustSpeed * Time.deltaTime);
	
		if(reversed == false){
			offset += 0.1f*Time.deltaTime;
		}
		else{
			offset -= 0.1f*Time.deltaTime;
		}

		// aMaterial.
		aMaterial.SetTextureOffset("_MainTex", new Vector2(offset/3, offset));

		
	}
	
	bool viewed = false;
	public float delay {
		get { return 0; }
	}  
	public void TriggerEffect () {
		if (!viewed) {
			viewed = true;
			dir = (int)Mathf.Sign (Random.Range (-2, 3));
			targScale = transform.localScale;	
			targScale.x = Random.Range (scaleMin, scaleMax) * dir;			
		}
	}
	public void CancelEffect () {
		viewed = false;
		targScale.x = 0;
	}
}
