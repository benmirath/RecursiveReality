using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Book : MonoBehaviour, IGazable {
	public float _delay = 4; 
	public float delay { get { return _delay; } }
	public Text mainBookTextL;
	public Text mainBookTextR;
	public Text[] bookTextL;
	public Text[] bookTextR;
	// public string[] textL;
	// public string[] textR;
	
	
	
	bool isBeingRead = false;
	int textIndex = 0;
	
	void Start () {
		textIndex = 0;
		mainBookTextL.text = bookTextL[Mathf.Clamp (textIndex, 0, bookTextL.Length)].text;
		mainBookTextR.text = bookTextR[Mathf.Clamp (textIndex, 0, bookTextR.Length)].text;
	}
	
	public void TriggerEffect () {
		isBeingRead = true;
	}
	public void CancelEffect () {
		if (isBeingRead) {
			isBeingRead = false;
			textIndex++;
			mainBookTextL.text = bookTextL[Mathf.Clamp (textIndex, 0, bookTextL.Length)].text;
			mainBookTextR.text = bookTextR[Mathf.Clamp (textIndex, 0, bookTextR.Length)].text;
		}
	}
	
}
