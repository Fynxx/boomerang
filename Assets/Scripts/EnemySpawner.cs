using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public int chance;
	public int random;
	public int direction;
	public int range;
	public Vector3 spawnLocation;
	public Vector3 playerLocation;
	public GameObject enemy;
	public GameObject player;

	// Use this for initialization
	void Start () {
		chance = 200;
		range = 10;
		player = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		random = Random.Range (1, chance);

		if (random == 1) {
			Instantiate (enemy, spawnLocation, Quaternion.identity);
		}
		CalculateSpawnLocation ();
	}

	void CalculateSpawnLocation(){
		playerLocation = player.transform.position;

		switch (direction) {
		case 1:
			spawnLocation = new Vector3 (playerLocation.x + range, playerLocation.y, playerLocation.z);
			print ("north");
			break;
		case 2:
			spawnLocation = new Vector3 (playerLocation.x - range, playerLocation.y, playerLocation.z);
			break;
		case 3:
			spawnLocation = new Vector3 (playerLocation.x, playerLocation.y + range, playerLocation.z);
			break;
		case 4:
			spawnLocation = new Vector3 (playerLocation.x, playerLocation.y - range, playerLocation.z);
			break;
		default:
			print ("switch statement broken");
			break;
		}
		direction = Random.Range (1, 4);
	}
}
