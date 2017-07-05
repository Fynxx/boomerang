using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandardBoomerang : BoomerangMother {

	public void Start () {
		speed = 100;
		range = 3;
		damage = 50;
		rotationMultiplier = 1000;
	}
		
}
