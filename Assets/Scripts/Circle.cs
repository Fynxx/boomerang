using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
	public int segments;
	public float xradius;
	public float yradius;
	LineRenderer line;
	public BoomerangController boomerangController;

	void Start ()
	{
		line = gameObject.GetComponent<LineRenderer>();

		line.SetVertexCount (segments + 1);
		line.useWorldSpace = false;

	}

	void Update (){
		line.transform.position = boomerangController.rotationPoint;
		if (boomerangController.charging == true) {
			if (xradius * 2 <= boomerangController.selectedBoomerang.range) {
				xradius += 0.05f;
				yradius += 0.05f;
			}
		} else {
			xradius = 0;
			yradius = 0;
		}
		CreatePoints ();
	}


	void CreatePoints ()
	{
		float x;
		float y;
		float z = 0f;

		float angle = 20f;

		for (int i = 0; i < (segments + 1); i++)
		{
			x = Mathf.Sin (Mathf.Deg2Rad * angle) * xradius;
			y = Mathf.Cos (Mathf.Deg2Rad * angle) * yradius;

			line.SetPosition (i,new Vector3(x,y,z) );

			angle += (360f / segments);
		}
	}
}