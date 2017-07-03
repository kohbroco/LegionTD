using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{

	//GridUnit[] gridUnits = new GridUnit[]();
	public GameObject gridUnitPrefab;

	public GameObject reference1TL;
	public GameObject reference1BR;

	public GameObject reference2TL;
	public GameObject reference2BR;

	public int gridWidth;
	public int gridHeight;
	public float spacing;

	// Use this for initialization
	void Start ()
	{
		Vector2 topLeft = new Vector2 (reference1TL.transform.position.x, reference1TL.transform.position.z);
		Vector2 bottomRight = new Vector2 (reference1BR.transform.position.x, reference1BR.transform.position.z);
		SpawnGrid (topLeft, bottomRight, true);
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void SpawnGrid (Vector2 topLeft, Vector2 bottomRight, bool stickToTopLeft)
	{		

		#region measurements
		float gridSpaceWidth = Mathf.Abs (bottomRight.x - topLeft.x);
		float gridSpaceHeight = Mathf.Abs (bottomRight.y - topLeft.y);
		float gridSpaceLength;
		int gridLength;

		//compares to decide to base it on height or width (based on which is smaller)
		if (gridSpaceWidth > gridSpaceHeight) {
			gridSpaceLength = gridSpaceHeight;
			gridLength = gridHeight;
		} else {
			gridSpaceLength = gridSpaceWidth;
			gridLength = gridWidth;
		}


		float gapCounts = (gridWidth - 1);
		float gapTotalSpace = gapCounts * spacing;
		float gridUnitScale = Mathf.Abs ((gridSpaceLength - gapTotalSpace) / (gridLength));

		print ("total gap: " + gapTotalSpace.ToString ());
		print ("total grid length: " + gridSpaceLength.ToString ());
		print ("scale: " + gridUnitScale.ToString ());

		#endregion


		GameObject gridGroup = GameObject.Instantiate (new GameObject ());

		for (int x = 0; x < gridWidth; x++) {
			for (int z = 0; z < gridHeight; z++) {

				//create
				GameObject gridUnit = GameObject.Instantiate (gridUnitPrefab, gridGroup.transform);
				
				//size
				gridUnit.transform.localScale = new Vector3 (gridUnitScale, gridUnitScale, gridUnitScale);

				#region position

				Transform gridUnitTransform = gridUnit.GetComponent<Transform> ();

				//adjust for map direction
				float xPosNegFactor = -(topLeft.x - bottomRight.x) / Mathf.Abs ((topLeft.x - bottomRight.x));
				float zPosNegFactor = -(topLeft.y - bottomRight.y) / Mathf.Abs ((topLeft.y - bottomRight.y));

				//because grid unit anchor is in the centre
				Vector3 offsetForAnchor = new Vector3 (xPosNegFactor * gridUnitScale / 2, 0, zPosNegFactor * gridUnitScale / 2);
				Vector3 offsetForBottomRight = Vector3.zero;

				//choose to follow tl marker or br marker
				if (!stickToTopLeft) {
					offsetForBottomRight = new Vector3 (gridSpaceWidth - gridSpaceLength, 0, gridSpaceHeight - gridSpaceLength);
				}

				//set position
				gridUnitTransform.position = new Vector3 (topLeft.x + xPosNegFactor * x * (gridUnitScale + spacing), reference1BR.transform.position.y + 0.05f, topLeft.y + zPosNegFactor * z * (gridUnitScale + spacing)) + offsetForAnchor + offsetForBottomRight;

				#endregion

				//set gridUnitData
				GridUnit gridUnitScript = gridUnit.GetComponent<GridUnit> ();
				gridUnitScript.gridCoordinate = new Vector2 (x, z);

				//color
				gridUnitScript.SetDefaultColor (Color.black);
			}				
		}





	}
}
