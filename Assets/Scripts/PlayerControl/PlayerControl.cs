using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{

	Camera camera;

	//runtime variables
	private float mouseDownTime = 0;
	private Vector3 lastTouchPosition;
	private bool wasLastFrameZooming = false;
	private float lastZoomDistance = 0;
	//this is set to true when exactly 2 touches were on screen


	public delegate void PlayerControlDelegate (Vector3 information);

	public PlayerControlDelegate longTouchEvent;
	public PlayerControlDelegate touchEndEvent;
	public PlayerControlDelegate touchBeginEvent;
	public PlayerControlDelegate touchMovedEvent;
	public PlayerControlDelegate touchZoomEvent;



	// Use this for initialization
	void Start ()
	{
		camera = this.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update ()
	{		

		#region touch delegate configurations
		//if mouse is held down
		if (Input.GetMouseButton (0)) {

			//check for touch movement
			if (lastTouchPosition != FirstTouchPosition ()) {
				if (touchMovedEvent != null) {
					touchMovedEvent (FirstTouchPosition ());				
				}

				lastTouchPosition = FirstTouchPosition ();
			}


			if (mouseDownTime > 0.2) {
				//trigger output long touch event	
				if (longTouchEvent != null) {
					longTouchEvent (Input.mousePosition);				
				}
			} else {
				mouseDownTime += Time.deltaTime;			
			}


		}
			

		if (Input.GetMouseButtonDown (0)) {
			if (touchBeginEvent != null) {
				touchBeginEvent (FirstTouchPosition ());			
			}
		}

		if (Input.GetMouseButtonUp (0)) {
			mouseDownTime = 0;
			//trigger touch up event		
			if (touchEndEvent != null) {
				touchEndEvent (FirstTouchPosition ());				
			}


		}

		//zoom
		if (Input.touchCount == 2) {
			Vector2 firstTouchCoordinates = Input.GetTouch (0).position;
			Vector2 secondTouchCoordinates = Input.GetTouch (1).position;


			Camera mainCamera = Camera.main;

			float touchDistance = Vector2.Distance (firstTouchCoordinates, secondTouchCoordinates);
			//print (touchDistance + " first: " + firstTouchWorldCoordinates.ToString () + " second: " + secondTouchWorldCoordinates.ToString ());

			if (wasLastFrameZooming) {

				float currentZoomDistance = touchDistance;
				float zoomDelta = (lastZoomDistance - currentZoomDistance);

				if (touchZoomEvent != null) {
					touchZoomEvent (new Vector3 (0, zoomDelta, 0));
				}

				lastZoomDistance = currentZoomDistance;

			} else {

				lastZoomDistance = touchDistance;

				wasLastFrameZooming = true;
			}

		} else {
			//end zoom
			wasLastFrameZooming = false;
			lastZoomDistance = 0;

		}
		#endregion


	}

	private Vector3 FirstTouchPosition ()
	{
		if (Input.touchCount == 0) {
			return Input.mousePosition;
		} else {
			return Input.GetTouch (0).position;
		}
	}

}
