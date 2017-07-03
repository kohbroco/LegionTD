using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minion : MonoBehaviour
{
	public int max_health = 2;

	public float velocity = 0.1f;

	public Vector3 initial_direction = new Vector3 (0, 0, 1);
	public Health health;
	public Movement movement;
	public Targeting targeting;
	//public Vector3 destination;
	public IAction default_action;
	// Use this for initialization

	public WayPoint movementTarget;

	void Start ()
	{
		this.health = this.gameObject.AddComponent<Health> ();
		this.health.Init (max_health);
		this.health.Die += Died;

		this.movement = this.gameObject.AddComponent<Movement> ();
		this.movement.Init (this.velocity);
		this.movement.SetTarget (this.movementTarget);

		this.targeting = this.gameObject.AddComponent<Targeting> ();
		this.targeting.Init (15f, false);
		this.targeting.TargetAcquired += TargetAcquired;
		this.targeting.TargetLost += TargetLost;

		this.default_action = this.gameObject.AddComponent<Attack> ();
		this.gameObject.AddComponent<Targetable> ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	void Died ()
	{
		GameObject.Destroy (this.gameObject);
	}

	void TargetAcquired (GameObject target)
	{
		this.movement.Stop ();
		this.default_action.Perform (target);
		Debug.Log ("Attacking..." + target.name);
	}

	void TargetLost ()
	{
		this.movement.Start ();
	}
}
