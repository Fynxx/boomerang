using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBoomerang : BoomerangMother {

	public void Start () {
		speed = 300;
		range = 5;
		damage = 50;
		rotationMultiplier = 2000;
	}
		
}
