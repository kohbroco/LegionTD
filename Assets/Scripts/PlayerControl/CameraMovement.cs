using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CameraMovement : MonoBehaviour
{

	private Vector3 oldTouchPosition;

	public bool cameraMovementControlOn = true;
	public float zoomFactor = 0.10f;
	public float heightUpperLimit = 85f;
	public float lowerUpperLimit = 10f;


	// Use this for initialization
	void Start ()
	{
		PlayerControl playerControl = this.GetComponent<PlayerControl> ();
		playerControl.touchMovedEvent += TouchMovedEvent;
		playerControl.touchEndEvent += TouchEndEvent;
		playerControl.touchZoomEvent += ZoomCamera;


	}

	void TouchMovedEvent (Vector3 position)
	{
		//check for camera control
		if (!cameraMovementControlOn) {
			return;
		} 

		//check for ui penetration

		//need to move camera with same amount as moved on the ground
		if (EventSystem.current.IsPointerOverGameObject () || EventSystem.current.currentSelectedGameObject != null) {	
			return;
		}

		//get old and new touch position
		if (oldTouchPosition == new Vector3 (0, 0, 0)) {
			oldTouchPosition = position;
			return;
		}

		Vector3 newTouchPosition = position;

		//get distance on the ground
		float distanceMovedX = Camera.main.ScreenToWorldPoint (new Vector3 (newTouchPosition.x, newTouchPosition.y, this.transform.position.y)).x - Camera.main.ScreenToWorldPoint (new Vector3 (oldTouchPosition.x, oldTouchPosition.y, this.transform.position.y)).x;
		float distanceMovedZ = Camera.main.ScreenToWorldPoint (new Vector3 (newTouchPosition.x, newTouchPosition.y, this.transform.position.y)).z - Camera.main.ScreenToWorldPoint (new Vector3 (oldTouchPosition.x, oldTouchPosition.y, this.transform.position.y)).z;

		//move by this distance
		this.transform.position = new Vector3 (this.transform.position.x - distanceMovedX, this.transform.position.y, this.transform.position.z - distanceMovedZ);

		//update old position
		oldTouchPosition = position;
	}

	void TouchEndEvent (Vector3 position)
	{
		oldTouchPosition = new Vector3 (0, 0, 0);
	}

	void ZoomCamera (Vector3 info)
	{		
		Vector3 postulatedPosition = this.transform.position + info * zoomFactor;
		if (postulatedPosition.y > lowerUpperLimit && postulatedPosition.y < heightUpperLimit) {
			this.transform.position = postulatedPosition;
		}
	}
}
