using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : AvatarManager {

	public bool canMove;

	public BoomerangController bc;

	public List<BoomerangController> boomerangInventory = new List<BoomerangController>();

	void Start () 
	{
		canMove = true;
	}

	void Update () 
	{
		PlayerMovement ();
	}

	public void PlayerMovement()
	{
		if (canMove == true) {
			float verticalMove = Input.GetAxis("Vertical") * speed;
			float horizontalMove = Input.GetAxis("Horizontal") * speed;
			verticalMove *= Time.deltaTime;
			horizontalMove *= Time.deltaTime;
			transform.Translate (0, verticalMove, 0);
			transform.Translate (horizontalMove, 0, 0);
		}

	}

	void OnTriggerEnter2D(Collider2D boomerang) {
		if (boomerang.tag == "Boomerang") {
			bc.pickedUp = true;
			bc.flying = false;
		}

	}

//	void OnTriggerEnter2D(Collider2D treasure) {
//		if (treasure.tag == "Treasure") {
//			
//		}
//
//	}
		
}
