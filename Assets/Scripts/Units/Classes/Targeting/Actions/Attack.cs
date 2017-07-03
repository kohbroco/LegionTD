using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour, IAction
{
	public float coolDown = 1.0f;
	public int damage = 1;

	public float nextAttackTime;
	// Use this for initialization
	void Start ()
	{
		this.nextAttackTime = Time.fixedTime;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void Perform (GameObject receiver)
	{
		if (Time.fixedTime > this.nextAttackTime) {
			this.nextAttackTime += this.coolDown;
			Health health = receiver.gameObject.GetComponent<Health> ();
			if (health != null) {
				health.TakeDamage (this.damage);
			}	
		}
	}
}
