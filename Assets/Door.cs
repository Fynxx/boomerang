using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

	public int amountButtons;
	public GameObject[] buttons;


	// Use this for initialization
	void Start () {
		buttons = GameObject.FindGameObjectsWithTag ("Button");
		amountButtons = buttons.Length;
	}
	
	// Update is called once per frame
	void Update () {
		
		print(amountButtons);
	}

}
