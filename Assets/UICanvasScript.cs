using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICanvasScript : MonoBehaviour {

	public GameObject buildMenuGroup;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void ShowBuildMenu(Vector3 position)
	{
		RectTransform transform = buildMenuGroup.GetComponent<RectTransform> ();
		transform.position = position;

	}

	public void HideBuildMenu()
	{
		RectTransform transform = buildMenuGroup.GetComponent<RectTransform> ();
		transform.position = new Vector3 (-100,-100,-100);
	}
}
