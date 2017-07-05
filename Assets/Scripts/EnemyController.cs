using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public GameObject shield;
	public GameObject boomerang;
	public GameObject target;
	public BoomerangController boomerangController;
	public float speed;
	private Vector3 boomerangPosition;
	private Vector3 startRotation;
	private float randomRotation;

	void Start () {
		shield = GameObject.Find ("Shield");
		boomerang = GameObject.Find ("StandardBoomerang");
		target = GameObject.FindGameObjectWithTag ("Player");
		speed = 1;
		CalculateStartRotation ();
	}

	void CalculateStartRotation()
	{
		randomRotation = Random.Range (0, 360);
//		startRotation = new Vector3 (0, 0, randomRotation);
		transform.rotation = Quaternion.AngleAxis(randomRotation, Vector3.forward);
	}

	void Update () {
		MoveToPlayer ();
	}

	void MoveToPlayer(){
		float step = speed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.transform.position, step);
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Boomerang") {
			Destroy (this.gameObject);
//			shield.SetActive (false);
		}
	}
		
}
