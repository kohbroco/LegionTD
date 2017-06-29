using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridUnit : MonoBehaviour
{
	public Vector2 gridCoordinate;
	public GameObject currentTowerObject;


	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}


	public void Select (Color color)
	{
		gameObject.GetComponent<Renderer> ().material.color = color;
	}

	public void Deselect ()
	{
		gameObject.GetComponent<Renderer> ().material.color = Color.white;
	}

	public void SetCurrentTowerObject (GameObject towerToSet)
	{
		currentTowerObject = towerToSet;
	}

	public void RemoveCurrentTowerObject ()
	{
		currentTowerObject = null;	
	}

}
