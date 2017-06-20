using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class GridMenu : MonoBehaviour
{	
	Camera mainCamera;

	public GameObject semiCircleMenuGroup;
	private SemiCircleMenu semiCircleMenuScript;

	bool ignoreMenuCloseForMove = false;
	bool ignoreMenuOpenForMove = false;

	private GameObject selectedGridUnit;

	void Start ()
	{
		mainCamera = Camera.main;

		semiCircleMenuScript = semiCircleMenuGroup.GetComponent<SemiCircleMenu> ();

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
		if (semiCircleMenuScript.isOpen) {
			ignoreMenuCloseForMove = true;

			//update menu position
			RectTransform transform = this.GetComponent<RectTransform> ();
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
		
		if (semiCircleMenuScript.isOpen /*&& touch is not within option*/) {

			if(!ignoreMenuCloseForMove)
			{
				Close ();
			}

		} 
		else //if closed
		{
			//ray
			Ray ray = Camera.main.ScreenPointToRay (position);
			RaycastHit hitCast;
			Physics.Raycast (ray, out hitCast);

			//set selected grid

			if(hitCast.collider != null && hitCast.collider.gameObject != null)
			{
				selectedGridUnit = hitCast.collider.gameObject;
				Open ();
			}

		}

	}

	void Open ()
	{
		if(selectedGridUnit == null){print ("no selected grid unit");return;}

		if(ignoreMenuOpenForMove){return;}

		selectedGridUnit.GetComponent<Renderer> ().material.color = Color.blue;

		//Show Menu UI 
		semiCircleMenuScript.Open(selectedGridUnit.transform.position);
	}

	void Close ()
	{
		selectedGridUnit.GetComponent<Renderer> ().material.color = Color.white;

		selectedGridUnit = null;

		//Hide Menu UI
		semiCircleMenuScript.Close();
	}

	void MenuButtonClicked(int index)
	{
		print (index.ToString() + " clicked");
	}


}
