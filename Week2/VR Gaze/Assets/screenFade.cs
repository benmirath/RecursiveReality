using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class screenFade : MonoBehaviour {
	
	Image fadeImage;
	Color col;
	// Use this for initialization
	void Start () {
		fadeImage = GetComponent<Image> ();
		col = fadeImage.color;
	}
	
	// Update is called once per frame
	void Update () {
		col.a -= 0.5f * Time.deltaTime;
		fadeImage.color = col;
	}
}
