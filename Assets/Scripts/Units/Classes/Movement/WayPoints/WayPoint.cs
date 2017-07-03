using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
	public GameObject next;
	// Use this for initialization
	void Start ()
	{
		
	}


	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public Vector3 GetPosition ()
	{
		return this.transform.position;
	}
	//Returns the next position to go to
	public WayPoint Next ()
	{
		WayPoint next_wp = next.GetComponent<WayPoint> ();
		return next_wp;
	}
}
