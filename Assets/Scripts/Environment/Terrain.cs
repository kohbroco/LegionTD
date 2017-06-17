using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Terrain : MonoBehaviour {

	//GridUnit[] gridUnits = new GridUnit[](); 
	public GameObject gridUnitPrefab;


	public int gridWidth;
	public int gridLength;

	// Use this for initialization
	void Start () {
		SpawnGrid ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnGrid()
	{
		for(int x = 0; x < gridWidth; x ++)
		{
			for(int y = 0; y < gridLength; y ++)
			{
				GameObject gridUnit = GameObject.Instantiate(gridUnitPrefab);
				Transform gridUnitTransform = gridUnit.GetComponent<Transform> ();
				gridUnitTransform.position = new Vector3 (x*2.01f,0,y*2.01f);
			}				
		}			
	}
}
