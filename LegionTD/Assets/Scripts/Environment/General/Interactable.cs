using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Interactable : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void CheckForCollider()
	{
		MeshCollider meshCollider = this.GetComponent<MeshCollider> ();
	}
		
	public void Interact()
	{

	}
}

public interface IsInteractable
{
	void Interact();
}

