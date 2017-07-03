using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Targeting : MonoBehaviour
{
	public delegate void TargetAcquiredDelegate (GameObject target);

	public TargetAcquiredDelegate TargetAcquired;

	public delegate void TargetLostDelegate ();

	public TargetLostDelegate TargetLost;

	public float radius;
	public bool target_all;

	public void Init (float radius, bool target_all)
	{
		this.radius = radius;
		this.target_all = target_all;
	}

	public void Update ()
	{
		this.AcquireTarget (this.gameObject.transform.position, this.radius, this.target_all);
	}

	private void AcquireTarget (Vector3 origin, float radius, bool target_all)
	{
		Collider[] targets_colliders = Physics.OverlapSphere (origin, radius);
		var target_acquired = false;
		if (targets_colliders.Length != 0) {
			foreach (Collider target_collider in targets_colliders) {
				var target = target_collider.gameObject;
				if (this.gameObject != target) { //Ignore target if target is self
					Targetable targetable = target.GetComponent<Targetable> (); //Assume targetable if target has health
					if (targetable != null) {
						target_acquired = true;
						this.TargetAcquired (target);
						if (!this.target_all) { //If not target all, stop after finding one target
							break;
						}
					}
				}

			}
		}
		if (!target_acquired) {
			this.TargetLost ();
		}
	}
}
