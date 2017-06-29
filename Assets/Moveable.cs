using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moveable : MonoBehaviour
{

	// Use this for initialization
	void Start ()
	{
		NavMeshAgent agent = GetComponent<NavMeshAgent> ();
		agent.SetDestination (new Vector3 (20, 0, 0));

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
}
