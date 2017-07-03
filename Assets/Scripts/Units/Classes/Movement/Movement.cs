using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

public class Movement : MonoBehaviour
{
	public Vector3 direction { get; set; }

	public float maxVelocity { get; set; }

	private float currentVelocity { get; set; }

	private const float MAX_DEVIATION = 0.5f;

	private NavMeshAgent navMeshAgent;

	public WayPoint target;

	public void Init (float max_velocity)
	{
		this.maxVelocity = max_velocity;
		this.currentVelocity = this.maxVelocity;

		navMeshAgent = this.gameObject.AddComponent<NavMeshAgent> ();
		navMeshAgent.speed = this.maxVelocity;
		navMeshAgent.acceleration = 99999;
	}

	public void SetTarget (WayPoint target)
	{
		this.target = target;
		navMeshAgent.SetDestination (this.target.GetPosition ());
		navMeshAgent.isStopped = false;
	}

	public void Update ()
	{
		this.CheckWayPoint ();
	}

	public void Start ()
	{
		navMeshAgent.isStopped = false;
		navMeshAgent.SetDestination (target.GetPosition ());
	}

	public void Stop ()
	{
		navMeshAgent.isStopped = true;
	}

	private void CheckWayPoint ()
	{
		//Check if destination has been reached -> remaining distance is shorter than (buffer = MAX_DEVIATION + stopping distance)
		if (navMeshAgent.remainingDistance < (MAX_DEVIATION + navMeshAgent.stoppingDistance)) {
			//reached, so go to next waypoint
			this.target = this.target.Next ();
			navMeshAgent.SetDestination (this.target.GetPosition ());
		}
	}
}
