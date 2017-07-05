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
			transform.Rotate(Vector3.forward * rotationMultiplier * Time.deltaTime);
		}
	}
}
