using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;



public class SemiCircleMenu : MonoBehaviour
{	
	public delegate void MenuButtonDelegate(int index);
	public MenuButtonDelegate menuButtonPressed;

	public GameObject buttonPrefab;
	public Sprite[] buttonImages;
	public float buttonDistanceFromCenter;

	public bool isOpen = false;

	void Awake()
	{

		float angleBetweenButtons = Mathf.PI/ buttonImages.Length;

		for(int i = 0; i < buttonImages.Length; i++)
		{
			float thisButtonAngle = (i - (buttonImages.Length-1)/2) * angleBetweenButtons;
			float x = Mathf.Cos (thisButtonAngle + Mathf.PI/2) * buttonDistanceFromCenter;
			float y = Mathf.Sin (thisButtonAngle + Mathf.PI/2) * buttonDistanceFromCenter;


			Sprite image = buttonImages[i];
			GameObject newButton = GameObject.Instantiate(buttonPrefab,new Vector3(0,0,0),Quaternion.identity,this.transform);

			newButton.transform.localPosition = new Vector3 (x,y,0);
			print ("creating button");

			Button buttonScript = newButton.GetComponent<Button> ();
			if (buttonScript != null)
			{
				buttonScript.image.sprite = image;
				buttonScript.onClick.AddListener (delegate{MenuButtonClicked(i);}); 

				//buttonScript.onClick = Start;
			}
			else
			{
				print("no button script");
			}
		}
	}


	public void Open (Vector3 worldPointPosition)
	{
		isOpen = true;

		//Show Menu UI 
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = Camera.main.WorldToScreenPoint(worldPointPosition);
	}

	public void Close ()
	{
		isOpen = false;

		//Hide Menu UI
		RectTransform transform = this.GetComponent<RectTransform> ();
		transform.position = new Vector3 (-1000,-1000,-100);
	}

	void MenuButtonClicked(int index)
	{
		menuButtonPressed (index);
	}


}
