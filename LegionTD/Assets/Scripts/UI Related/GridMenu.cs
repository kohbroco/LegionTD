using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridMenu : MonoBehaviour
{

	public GameObject canvas;
	public GameObject buildMenuGroup;

	Camera mainCamera;

	bool ignoreMenuCloseForMove = false;
	bool ignoreMenuOpenForMove = false;

	private GameObject selectedGridUnit;
	bool towerMenuOpen = false;

	// Use this for initialization
	void Start ()
	{

		//get playerControl script and subscribe to events
		mainCamera = Camera.main;
		PlayerControl playerControl = mainCamera.GetComponent<PlayerControl> ();
//		playerControl.longTouchEvent += LongTouchEvent;
		playerControl.touchBeginEvent += TouchBeginEvent;
		playerControl.touchEndEvent += TouchEndEvent;
		playerControl.touchMovedEvent += TouchMovedEvent;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	void TouchMovedEvent(Vector3 position)
	{
		if (towerMenuOpen) {
			ignoreMenuCloseForMove = true;

			//update menu position
			RectTransform transform = buildMenuGroup.GetComponent<RectTransform> ();
			transform.position = mainCamera.WorldToScreenPoint (selectedGridUnit.transform.position);
		}
		else 
		{
			ignoreMenuOpenForMove = true;
		}
	}
//	void LongTouchEvent (Vector3 position)
//	{
//		
//	}
//
	void TouchBeginEvent (Vector3 position)
	{
		ignoreMenuCloseForMove = false;
		ignoreMenuOpenForMove = false;
	}

	void TouchEndEvent (Vector3 position)
	{
		
		if (towerMenuOpen /*&& touch is not within option*/) {

			if(!ignoreMenuCloseForMove)
			{
				CloseTowerMenu ();
			}

		} 
		else //if closed
		{
			//ray
			Ray ray = Camera.main.ScreenPointToRay (position);
			RaycastHit hitCast;
			Physics.Raycast (ray, out hitCast);

			//set selected grid
			selectedGridUnit = hitCast.collider.gameObject;
			OpenTowerMenu ();
		}

	}

	void OpenTowerMenu ()
	{
		if(selectedGridUnit == null){print ("no selected grid unit");return;}

		if(ignoreMenuOpenForMove){return;}

		towerMenuOpen = true;

		selectedGridUnit.GetComponent<Renderer> ().material.color = Color.blue;

		//Show Menu UI 
		RectTransform transform = buildMenuGroup.GetComponent<RectTransform> ();
		transform.position = mainCamera.WorldToScreenPoint(selectedGridUnit.transform.position);
	}

	void CloseTowerMenu ()
	{
		towerMenuOpen = false;

		selectedGridUnit.GetComponent<Renderer> ().material.color = Color.white;

		selectedGridUnit = null;

		//Hide Menu UI
		RectTransform transform = buildMenuGroup.GetComponent<RectTransform> ();
		transform.position = new Vector3 (-100,-100,-100);
	}

}
