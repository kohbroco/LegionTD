using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour {

	private Vector3 oldTouchPosition;
	// Use this for initialization
	void Start () {
		PlayerControl playerControl = this.GetComponent<PlayerControl> ();
		playerControl.touchMovedEvent += TouchMovedEvent;
		playerControl.touchEndEvent += TouchEndEvent;

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void TouchMovedEvent(Vector3 position)
	{
		//need to move camera with same amount as moved on the ground

		//get old and new touch position
		if(oldTouchPosition == new Vector3(0,0,0))
		{
			oldTouchPosition = position;
			return;
		}

		Vector3 newTouchPosition = position;

		//get distance on the ground
		float distanceMovedX = Camera.main.ScreenToWorldPoint(new Vector3(newTouchPosition.x,newTouchPosition.y,this.transform.position.y)).x - Camera.main.ScreenToWorldPoint(new Vector3(oldTouchPosition.x,oldTouchPosition.y,this.transform.position.y)).x;
		float distanceMovedZ = Camera.main.ScreenToWorldPoint(new Vector3(newTouchPosition.x,newTouchPosition.y,this.transform.position.y)).z - Camera.main.ScreenToWorldPoint(new Vector3(oldTouchPosition.x,oldTouchPosition.y,this.transform.position.y)).z;

		this.transform.position = new Vector3(this.transform.position.x - distanceMovedX,this.transform.position.y,this.transform.position.z - distanceMovedZ) ;

		oldTouchPosition = position;
	}

	void TouchEndEvent(Vector3 position)
	{
		oldTouchPosition = new Vector3(0,0,0);
	}

}
