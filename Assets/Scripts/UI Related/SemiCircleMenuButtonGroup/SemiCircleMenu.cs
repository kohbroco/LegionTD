using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;



public class SemiCircleMenu : MonoBehaviour
{
	public delegate void MenuButtonDelegate (int index);

	public MenuButtonDelegate menuButtonDown;
	public MenuButtonDelegate menuButtonUp;

	public GameObject buttonPrefab;
	public Sprite[] buttonImages;
	public float buttonDistanceFromCenter;
	public float buttonHeight;

	public bool isOpen = false;

	void Awake ()
	{

		float angleBetweenButtons = Mathf.PI / buttonImages.Length;

		for (int i = 0; i < buttonImages.Length; i++) {

			//get coordinates for spawn
			float thisButtonAngle = (i - (buttonImages.Length - 1) / 2) * angleBetweenButtons;
			float x = Mathf.Cos (thisButtonAngle + Mathf.PI / 2) * buttonDistanceFromCenter;
			float y = Mathf.Sin (thisButtonAngle + Mathf.PI / 2) * buttonDistanceFromCenter;

			//spawn
			GameObject newButton = GameObject.Instantiate (buttonPrefab, new Vector3 (0, 0, 0), Quaternion.identity, this.transform);
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
				MenuButtonDown (index);
			});

			//event trigger up
			EventTrigger.Entry pointerUp = new EventTrigger.Entry ();
			pointerUp.eventID = EventTriggerType.PointerUp;
			pointerUp.callback.AddListener ((eventData) => {
				MenuButtonUp (index);
			});


			eventTriggerScript.triggers.Add (pointerDown);
			eventTriggerScript.triggers.Add (pointerUp);

			#endregion

			#region set button image
			Button buttonScript = newButton.GetComponent<Button> ();
			if (buttonScript != null) {
				//change button image
				Sprite image = buttonImages [i];
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
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = Camera.main.WorldToScreenPoint (worldPointPosition);

		OnOpened ();
	}

	public void Close ()
	{
		isOpen = false;

		//Hide Menu UI
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = new Vector3 (-1000, -1000, -100);

		OnClosed ();
	}

	public abstract void OnOpened ();

	public abstract void OnClosed ();

	public abstract void DidPressMenuItem (int index);

	public abstract void DidReleaseMenuItem (int index);

	public void MoveToWorldPosition (Vector3 destination)
	{
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = Camera.main.WorldToScreenPoint (destination);
	}

	public void MoveToScreenPosition (Vector3 destination)
	{
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = destination;
	}


	void MenuButtonDown (int index)
	{
		if (menuButtonDown != null) {
			menuButtonDown (index);		
		}
	}

	void MenuButtonUp (int index)
	{		
		if (menuButtonUp != null) {
			menuButtonUp (index);		
		}
	}




}
