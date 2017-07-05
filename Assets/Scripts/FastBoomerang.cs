using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FastBoomerang : BoomerangMother {

	public void Start () {
		speed = 100;
		range = 5;
		damage = 30;
		rotationMultiplier = 10;
	}
}
