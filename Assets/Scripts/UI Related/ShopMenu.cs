using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopMenu : TabListMenu
{

	// Use this for initialization
	public GridUnit selectedGridUnit;
	public bool isOpen;
	// Update is called once per frame
	void Update ()
	{
		
	}

	public override void Initialize ()
	{
		menuUIObject.GetComponent<Image> ().color = new Color32 (0, 102, 102, 255);
	}


	public override int numberOfTabs ()
	{
		return 4;
	}

	public override string titleForTab (int tabNumber)
	{		
		string[] titles = { "Warrior", "Mage", "Marksmen", "Aura" };
		return titles [tabNumber];

	}

	public override int numberOfCellsForTab (int tabNumber)
	{
		return 4;
	}



	public override GameObject cellForIndex (Vector2 indexPath)
	{
		return new GameObject ();
	}

	public override void OnOpened ()
	{
		isOpen = true;

		if (selectedGridUnit != null) {
			print ("on open shop");

			selectedGridUnit.Select (Color.yellow);
		}
	}

	public override void OnClosed ()
	{
		isOpen = false;

		if (selectedGridUnit != null) {
			selectedGridUnit.Deselect ();
			selectedGridUnit = null;
		}
	}

	public override void DidSelectCell (Vector2 indexPath)
	{
		print (indexPath.x.ToString () + "," + indexPath.y.ToString ());
	}


}
