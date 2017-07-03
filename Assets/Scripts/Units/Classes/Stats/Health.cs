using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	public delegate void HealthDelegate ();

	public HealthDelegate Die;

	public int value { get; set; }

	public void Init (int value)
	{
		this.value = value;
	}

	public void TakeDamage (int damage)
	{
		//Guard check damage is only positive
		if (damage < 0) {
			return;
		}

		this.value -= damage;
		Debug.Log (value);
		if (this.value <= 0 && (this.Die != null)) {
			this.Die ();
		}
	}
}
