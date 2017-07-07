using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangController : MonoBehaviour {

	public GameObject boomerangObject;
	public GameObject boomerangTarget;
	public GameObject boomerangCrosshair;
	public GameObject boomerang;
	public GameObject boomerangOrigin;
	public GameObject boomerangPath;
	public GameObject player;

	public PlayerController playerController;

	public Vector3 rotationPoint;
	public Vector3 zeroPercent;
	public Vector3 hundredPercent;
	public Vector3 eightyPercent;

	public BoomerangMother[]  boomerangs;
	public BoomerangMother selectedBoomerang;

	public bool charging;
	public bool flying;
	public bool midPoint;
	public bool pickedUp;
	public bool reticleVisible;
	public bool clockWise;


	public TrailRenderer tr;

	public CircleCollider2D boomerangCollider;

	public Camera cam;
	//private GameObject gob; // we will place this object at the mouse position

	// Use this for initialization
	void Start () {
		midPoint = false;
		selectedBoomerang = boomerangs[0];
		pickedUp = true;
		zeroPercent = new Vector3 (0, 0, 0);
		hundredPercent = new Vector3 (1, 1, 1);
		eightyPercent = new Vector3 (.8f, .8f, 1);
		boomerangCollider = boomerang.GetComponent<CircleCollider2D>();
		//gob = new GameObject();
//		tr = boomerang.GetComponent<TrailRenderer> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		CreateBoomerangPath ();
		//NewReticle();
		ReticleMouse();
//		SelectBoomerang ();
		BoomerangInventory ();
		ErrorChecks ();
	}

	void BoomerangInventory(){
		if (pickedUp == true) {
			boomerang.transform.position = player.transform.position;
			boomerang.transform.localScale = zeroPercent;
		}
	}

	void ReticleMouse(){
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit = new RaycastHit();
		if (Physics.Raycast (ray, out hit, 100)) {
			Vector3 hitPoint = hit.point;

			Vector3 targetDir = hitPoint - transform.position;

			float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
			transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		}
		boomerangCrosshair.transform.localPosition = new Vector3 (selectedBoomerang.range, 0, 0);
	}

	void CreateBoomerangPath()
	{
		if (pickedUp == true) {
//			Vector3 crosshair = boomerangCrosshair.transform.position;

			if (Input.GetButtonDown ("Fire1")) {
				clockWise = false;
			}
			if (Input.GetButtonDown ("Fire2")) {
				clockWise = true;
			}

			if (Input.GetButtonDown ("Fire1") || Input.GetButtonDown ("Fire2")) {
				boomerangTarget.transform.position = player.transform.position;
				boomerangOrigin.transform.position = player.transform.position;
				boomerang.transform.position = boomerangOrigin.transform.position;
				ShowReticle ();
			}

			if (Input.GetButton ("Fire1") || Input.GetButton ("Fire2")) {
				charging = true;
			}

			if (Input.GetButtonUp ("Fire1") || Input.GetButtonUp ("Fire2")) {
				charging = false;
				flying = true;
				pickedUp = false;
				ShowReticle ();
				boomerangPath.transform.localScale = new Vector3(0,0,0);
			}

			if (charging == true) {
				Vector3 difference = boomerangCrosshair.transform.position - boomerangTarget.transform.position;
				boomerangTarget.transform.position += difference.normalized * .1f;
				playerController.canMove = false;
				CalculatingCircleMiddle ();
			} 

		}

		if (flying == true) {
			BoomerangRotation ();
			playerController.canMove = true;
			boomerang.transform.localScale = hundredPercent;
			boomerangCollider.enabled = true;
//			tr.enabled = true;
		} else {
//			tr.enabled = false;
			boomerang.transform.localScale = eightyPercent;
		}
	}

	void BoomerangRotation()
	{
		Vector3 rotationDirection = Vector3.back;

		if (clockWise == true) {
			rotationDirection = Vector3.forward;
		} else if (clockWise == false) {
			rotationDirection = Vector3.back;
		}

		boomerang.transform.RotateAround(rotationPoint, rotationDirection, (selectedBoomerang.speed * Time.deltaTime));
	}

	void CalculatingCircleMiddle()
	{
		rotationPoint = (boomerangTarget.transform.position + boomerangObject.transform.position) * 0.5f;
		boomerangPath.transform.position = rotationPoint;
		if (boomerangPath.transform.localScale.x <= selectedBoomerang.range) {
			boomerangPath.transform.localScale += new Vector3(0.1f, 0.1f, 0);
		}

	}

//	void SelectBoomerang(){
//		if (Input.GetKeyDown(KeyCode.Alpha1)){
//			selectedBoomerang = boomerangs[0];
//		}
//		if (Input.GetKeyDown(KeyCode.Alpha2)){
//			selectedBoomerang = boomerangs[1];
//		}
//	}

	void ShowReticle(){
		reticleVisible = !reticleVisible;

		if (reticleVisible == true) {
			boomerangTarget.GetComponent<SpriteRenderer> ().enabled = false;
		} else {
			boomerangTarget.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}

	void ErrorChecks(){
		print ("boomerang speed " + selectedBoomerang.speed);
	}
}
