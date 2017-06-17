using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	Camera camera;
	private float mouseDownTime = 0;

	public delegate void PlayerControlDelegate(Vector3 information);
	public PlayerControlDelegate longTouchEvent;
	public PlayerControlDelegate touchEndEvent;
	public PlayerControlDelegate touchBeginEvent;
	public PlayerControlDelegate touchMovedEvent;



	// Use this for initialization
	void Start () {
		camera = this.GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {		

		#region touch delegate configurations
		//if mouse is held down
		if (Input.GetMouseButton (0)) {

			//check for touch movement
			if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 )
			{
				if(touchMovedEvent != null)
				{
					touchMovedEvent (Input.mousePosition);				
				}
			}


			if (mouseDownTime > 0.2) {
				//trigger output long touch event	
				if(longTouchEvent != null)
				{
					longTouchEvent (Input.mousePosition);				
				}
			}
			else 
			{
				mouseDownTime += Time.deltaTime;			
			}


		}

		if(Input.GetMouseButtonDown(0))
		{
			if(touchBeginEvent != null)
			{
				touchBeginEvent(Input.mousePosition);			
			}
		}

		if(Input.GetMouseButtonUp(0))
		{
			mouseDownTime = 0;
			//trigger touch up event		
			if(touchEndEvent != null)
			{
				touchEndEvent (Input.mousePosition);				
			}
		}
		#endregion


	}

}
