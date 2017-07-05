using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour {

	public SpriteRenderer color;
	public bool isOn;

	// Use this for initialization
	void Start () {
		isOn = true;
		color = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (isOn == true) {
			color.color = Color.white;
		} else {
			color.color = Color.black;
		}
		
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Boomerang") {
			isOn = false;
		}

	}
}
