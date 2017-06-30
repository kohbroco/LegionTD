using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public abstract class SemiCircleMenu : MonoBehaviour
{
	public GameObject buttonPrefab;


	public GameObject semiCircleMenuGroup;

	public bool isOpen = false;

	void Awake ()
	{
		//spawn menu button group
		semiCircleMenuGroup = GameObject.Instantiate (new GameObject (), new Vector3 (-1000, -1000, -1000), Quaternion.identity, this.transform);
		semiCircleMenuGroup.AddComponent<RectTransform> ();
		semiCircleMenuGroup.name = "SemiCircleMenuGroup";

		int noOfButtons = NumberOfButtons ();
		float angleBetweenButtons = Mathf.PI / (noOfButtons - 1);

		for (int i = 0; i < noOfButtons; i++) {

			//get coordinates for spawn
			float thisButtonAngle = (i - (noOfButtons - 1) / 2) * angleBetweenButtons;
			float x = Mathf.Cos (thisButtonAngle + Mathf.PI / 2) * buttonDistanceFromCenter ();
			float y = Mathf.Sin (thisButtonAngle + Mathf.PI / 2) * buttonDistanceFromCenter ();

			//spawn menu button
			GameObject newButton = GameObject.Instantiate (buttonPrefab, new Vector3 (0, 0, 0), Quaternion.identity, semiCircleMenuGroup.transform);
			newButton.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, buttonHeight ());
			newButton.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Horizontal, buttonHeight ());
			newButton.transform.localPosition = new Vector3 (x, y, 0);

			int index = i;


			//get or add eventTriggerScript to each button
			EventTrigger eventTriggerScript = newButton.GetComponent<EventTrigger> ();
			if (eventTriggerScript == null) {
				eventTriggerScript = newButton.AddComponent<EventTrigger> ();
			}


			#region menu button trigger callbacks:

			//event trigger down
			EventTrigger.Entry pointerDown = new EventTrigger.Entry ();
			pointerDown.eventID = EventTriggerType.PointerDown;
			pointerDown.callback.AddListener ((eventData) => {
				DidPressMenuItem (index);
			});

			//event trigger up
			EventTrigger.Entry pointerUp = new EventTrigger.Entry ();
			pointerUp.eventID = EventTriggerType.PointerUp;
			pointerUp.callback.AddListener ((eventData) => {
				DidReleaseMenuItem (index);
			});


			eventTriggerScript.triggers.Add (pointerDown);
			eventTriggerScript.triggers.Add (pointerUp);

			#endregion

			#region set button image
			Button buttonScript = newButton.GetComponent<Button> ();
			if (buttonScript != null) {
				//change button image
				Sprite image = ImageForButtonAtIndex (i);
				buttonScript.image.sprite = image;
			} else {
				print ("no button script");
			}
			#endregion
		}
	}



	public void Open (Vector3 worldPointPosition)
	{
		isOpen = true;

		//Show Menu UI 
		RectTransform transform = semiCircleMenuGroup.GetComponent<RectTransform> ();
		transform.position = Camera.main.WorldToScreenPoint (worldPointPosition);

		OnOpened ();
	}

	public void Close ()
	{
		isOpen = false;

		//Hide Menu UI
		RectTransform transform = semiCircleMenuGroup.GetComponent<RectTransform> ();
		transform.position = new Vector3 (-1000, -1000, -100);

		OnClosed ();
	}

	public void MoveMenuToWorldPosition (Vector3 destination)
	{
		RectTransform menuTransform = semiCircleMenuGroup.GetComponent<RectTransform> ();
		menuTransform.position = Camera.main.WorldToScreenPoint (destination);
	}

	public void MoveMenuToScreenPosition (Vector3 destination)
	{
		RectTransform menuTransform = semiCircleMenuGroup.GetComponent<RectTransform> ();
		menuTransform.position = destination;
	}


	public abstract int NumberOfButtons ();

	public abstract Sprite ImageForButtonAtIndex (int index);


	public abstract float buttonDistanceFromCenter ();

	public abstract float buttonHeight ();


	public abstract void DidPressMenuItem (int index);

	public abstract void DidReleaseMenuItem (int index);


	public virtual void OnOpened ()
	{
	}

	public virtual void OnClosed ()
	{
	}




}
