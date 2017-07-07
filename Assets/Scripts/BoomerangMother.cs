using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangMother : MonoBehaviour {

	public float speed;
	public float range;
	public float damage;
	public float rotationMultiplier;

	public BoomerangController bc;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Origin" || other.tag == "Shield") {
			bc.flying = false;
		}

	}

	void Update(){
		if (bc.flying == true) {
			if (bc.clockWise == true) {
				transform.Rotate (Vector3.forward * rotationMultiplier * Time.deltaTime);
			}
			if (bc.clockWise == false) {
				transform.Rotate (Vector3.back * rotationMultiplier * Time.deltaTime);
			}
		}
	}
}
