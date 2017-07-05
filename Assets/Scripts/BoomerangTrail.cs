using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangTrail : MonoBehaviour {

	public TrailRenderer boomerangTrail;
	public BoomerangController boomerangController; 

	// Use this for initialization
	void Start () {
		boomerangTrail = gameObject.GetComponent<TrailRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (boomerangController.flying == true) {
			
		} else {
		
		}
			
	}
}
