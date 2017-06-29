using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class GridMenu : MonoBehaviour
{
	Camera mainCamera;

	public GameObject semiCircleMenuGroup;
	private SemiCircleMenu semiCircleMenuScript;

	bool ignoreMenuClose = false;
	bool ignoreMenuOpen = false;

	private GridUnit selectedGridUnit;
	private GridUnit proposedMoveToGridUnit;

	bool isMovingTower = false;

	void Start ()
	{
		mainCamera = Camera.main;

		semiCircleMenuScript = semiCircleMenuGroup.GetComponent<SemiCircleMenu> ();
		semiCircleMenuScript.menuButtonUp += menuButtonUp;
		semiCircleMenuScript.menuButtonDown += menuButtonDown;

		PlayerControl playerControl = mainCamera.GetComponent<PlayerControl> ();
		playerControl.touchBeginEvent += TouchBeginEvent;
		playerControl.touchEndEvent += TouchEndEvent;
		playerControl.touchMovedEvent += TouchMovedEvent;



	}


	// Update is called once per frame
	void Update ()
	{
		
	}

	void TouchMovedEvent (Vector3 position)
	{
		//if menu is open when touch is moved
		if (semiCircleMenuScript.isOpen) {
			ignoreMenuClose = true;

			if (isMovingTower) {

				ProposeTowerAtScreenPosition (position);

			} else {
				semiCircleMenuScript.MoveToWorldPosition (selectedGridUnit.transform.position);
			}

		} else {
			ignoreMenuOpen = true;
		}
	}

	void TouchBeginEvent (Vector3 position)
	{
		ignoreMenuClose = false;
		ignoreMenuOpen = false;
	}

	void TouchEndEvent (Vector3 position)
	{		
		
			
		if (semiCircleMenuScript.isOpen /*&& touch is not within option*/) {

			if (!ignoreMenuClose) {
				CloseMenu ();
			}

		} else { //if closed

			if (EventSystem.current.IsPointerOverGameObject () || EventSystem.current.currentSelectedGameObject != null) {	
				return;
			}

			selectedGridUnit = GetGridUnitFromScreenPosition (position);

			if (selectedGridUnit != null) {
				OpenMenu ();
			}



		}			
	}

	#region retrieve grid unit by position

	GridUnit GetGridUnitFromScreenPosition (Vector3 position)
	{
		//ray cast
		Ray ray = Camera.main.ScreenPointToRay (position);	
		RaycastHit hitCast;
		Physics.Raycast (ray, out hitCast);

		//return grid unit hit
		if (hitCast.collider != null && hitCast.collider.gameObject != null) {

			return hitCast.collider.gameObject.GetComponent<GridUnit> ();
		} else {
			return null;
		}
	}

	GridUnit GetGridUnitFromWorldPosition (Vector3 position)
	{
		//ray cast
		Ray ray = new Ray (Vector3.zero, position);
		RaycastHit hitCast;
		Physics.Raycast (ray, out hitCast);

		//return grid unit hit
		if (hitCast.collider != null && hitCast.collider.gameObject != null) {
			return hitCast.collider.gameObject.GetComponent<GridUnit> ();
		} else {
			return null;
		}
	}

	#endregion

	#region menu events

	void OpenMenu ()
	{
		//check if did select any grid unit
		if (selectedGridUnit == null) {
			print ("no selected grid unit");
			return;
		}

		//check to ignore (when moving)
		if (ignoreMenuOpen) {
			return;
		}

		//check if shop menu is open (cuz if it is, close shop menu)
		ShopMenu shop = this.gameObject.GetComponent<ShopMenu> ();

		if (shop.isOpen) {
			shop.Close ();
		}


		selectedGridUnit.Select (Color.blue);

		//Show Menu UI 
		semiCircleMenuScript.Open (selectedGridUnit.gameObject.transform.position);
	}

	void CloseMenu ()
	{
		selectedGridUnit.Deselect ();

		selectedGridUnit = null;

		//Hide Menu UI
		semiCircleMenuScript.Close ();
	}


	void menuButtonUp (int index)
	{
		switch (index) {
		case 0:
			{
				ShopMenu shop = gameObject.GetComponent<ShopMenu> ();
				shop.selectedGridUnit = selectedGridUnit;
				CloseMenu ();
				shop.Open ();


				break;
			}
		case 1:
			{
				print ("moving tower end");

				isMovingTower = false;

				StartCameraMovement ();

				MoveTowerToProposedUnit ();

				break;
			}

		case 2:
			{
				print ("deleting!");

				break;
			}
		}
	}

	void menuButtonDown (int index)
	{
		//1 is the move index
		if (index == 1) {
			print ("moving tower begin");
			isMovingTower = true;

			StopCameraMovement ();

		}


	}

	#endregion

	#region tower movement functions

	private void ProposeTowerAtScreenPosition (Vector3 position)
	{
		//Step 1: Move menu to touch
		semiCircleMenuScript.MoveToScreenPosition (new Vector3 (position.x, position.y - semiCircleMenuScript.buttonDistanceFromCenter * 0.6f, position.z));

		//Step 2: Reset previous proposition
		if (proposedMoveToGridUnit != null) {

			//dont want to deselect origin unit
			if (proposedMoveToGridUnit != selectedGridUnit) {
				proposedMoveToGridUnit.Deselect ();
			}						
		}

		//Step 3: Propose new position
		Vector3 proposedPosition = semiCircleMenuGroup.transform.position; //uses group as a reference as it is the center of the menu
		proposedMoveToGridUnit = GetGridUnitFromScreenPosition (proposedPosition);

		//Step 4a: Check for valid proposition
		if (proposedMoveToGridUnit == null) {
			print ("Proposal is not a gridUnit");
			return;
		}	
		//Step 4b: Check for valid proposition	
		if (proposedMoveToGridUnit.currentTowerObject == null) {

			//dont want to select origin unit
			if (proposedMoveToGridUnit != selectedGridUnit) {
				proposedMoveToGridUnit.Select (Color.green);
			}

		} else {
			proposedMoveToGridUnit.Select (Color.red);
		}
	}

	private void MoveTowerToProposedUnit ()
	{
		//Step 1: check for proposed unit
		if (proposedMoveToGridUnit == null) {
			print ("invalid proposed unit");
			SnapMenuToSelectedGridUnit ();
			return;
		}

		//Step 2: check for validity of proposed unit
		if (proposedMoveToGridUnit.currentTowerObject != null) {
			print ("invalid proposed unit; tower in place");

			//reset
			ResetProposedGridUnit ();

			SnapMenuToSelectedGridUnit ();
			return;
		}

		//step 3: move tower object 
		proposedMoveToGridUnit.SetCurrentTowerObject (selectedGridUnit.currentTowerObject);
		selectedGridUnit.RemoveCurrentTowerObject ();

		//step 4: reset color of old selection
		selectedGridUnit.Deselect ();

		//step 5: update selected unit
		selectedGridUnit = proposedMoveToGridUnit;

		//step 6: reset proposed unit
		ResetProposedGridUnit ();

		//step 7: set selectedGridUnit color (must do after Step 6 as proposedMoveToGridUnit=selectedGridUnit up till Step 6)
		selectedGridUnit.Select (Color.blue);

		//step 8: snap menu back to selection
		SnapMenuToSelectedGridUnit ();
	}


	private void SnapMenuToSelectedGridUnit ()
	{
		if (selectedGridUnit == null) {
			print ("no selected grid unit to snap to; closing menu");
			CloseMenu ();
			return;
		}

		semiCircleMenuScript.MoveToWorldPosition (selectedGridUnit.gameObject.transform.position);
	}

	private void ResetProposedGridUnit ()
	{
		if (proposedMoveToGridUnit != null) {
			proposedMoveToGridUnit.Deselect ();
			proposedMoveToGridUnit = null;
		}
	}


	#endregion

	#region manipulate camera movement

	private void StopCameraMovement ()
	{
		//get camera movement script
		CameraMovement camMoveScript = mainCamera.GetComponent<CameraMovement> ();
		if (camMoveScript == null) {
			print ("no camera movement script");
			return;
		}

		//set camera to stop moving
		camMoveScript.cameraMovementControlOn = false;
	}

	private void StartCameraMovement ()
	{
		//get camera movement script
		CameraMovement camMoveScript = mainCamera.GetComponent<CameraMovement> ();
		if (camMoveScript == null) {
			print ("no camera movement script");
			return;
		}

		//set camera to start moving
		camMoveScript.cameraMovementControlOn = true;
	}


	#endregion
}
