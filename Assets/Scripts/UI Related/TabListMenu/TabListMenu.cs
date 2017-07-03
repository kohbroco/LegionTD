using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public abstract class TabListMenu : MonoBehaviour
{
	//assets
	public GameObject buttonPrefab;

	public GameObject menuUIObject;
	public GameObject mainCellPanel;
	public GameObject mainTabPanel;
	public GameObject closeMenuButton;

	public Color themeDark;
	public Color themeMid;
	public Color themeBright;

	List<GameObject> tabsUIObjects = new List<GameObject> ();
	List<GameObject> cellUIObjects = new List<GameObject> ();



	void Awake ()
	{
		//spawn menu object - horizontal layout
		menuUIObject = GameObject.Instantiate (new GameObject ("tabListMenuGroup"), gameObject.transform); 
		menuUIObject.AddComponent <CanvasRenderer> ();
		menuUIObject.AddComponent<Image> ();
		menuUIObject.AddComponent<VerticalLayoutGroup> ().padding.left = 1;
		RectTransform rect = menuUIObject.GetComponent <RectTransform> ();
		//sets anchor to bottom of canvas
		rect.anchorMax = new Vector2 (1f, 0);
		rect.anchorMin = new Vector2 (0f, 0);
		rect.pivot = new Vector2 (0.5f, 0);
		rect.offsetMax = new Vector2 (0, rect.offsetMax.y);
		rect.offsetMin = new Vector2 (0, 0);
		rect.SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, menuHeight ());

		//spawn close button
		closeMenuButton = GameObject.Instantiate (new GameObject ("closeMenuButton"), menuUIObject.transform); 
		InitUIElement (closeMenuButton);
		LayoutElement closeMenuButtonLayoutElement = closeMenuButton.AddComponent<LayoutElement> ();
		closeMenuButtonLayoutElement.minHeight = 20f;
		closeMenuButtonLayoutElement.preferredHeight = 20f;
		closeMenuButton.AddComponent<Button> ().onClick.AddListener (Close);
		closeMenuButton.AddComponent<Shadow> ().effectDistance = new Vector2 (1, 5);

		//spawn mainTabPanel - vertical layout
		mainTabPanel = GameObject.Instantiate (new GameObject ("mainTabPanel"), menuUIObject.transform); 
		InitUIElement (mainTabPanel);
		mainTabPanel.AddComponent<HorizontalLayoutGroup> ();
		mainTabPanel.GetComponent<Image> ().color = Color.gray;
		mainTabPanel.AddComponent<LayoutElement> ().preferredHeight = tabHeight ();


		//spawn mainCellPanel - vertical layout (nested grid layouts for sections)
		mainCellPanel = GameObject.Instantiate (new GameObject ("mainCellPanel"), menuUIObject.transform); 
		InitUIElement (mainCellPanel);
		HorizontalLayoutGroup mainCellPanelHorizontalLayout = mainCellPanel.AddComponent<HorizontalLayoutGroup> ();
		mainCellPanelHorizontalLayout.spacing = 10f;
		mainCellPanelHorizontalLayout.padding = new RectOffset (10, 10, 10, 10);
		mainCellPanel.AddComponent<LayoutElement> ().flexibleHeight = 12;
		mainCellPanel.GetComponent<Image> ().color = themeMid;

		Initialize ();
	}

	// Use this for initialization
	void Start ()
	{
		ReloadTabsDisplay ();
		DidSelectTab (0);
		Close ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	}

	public void Open ()
	{
		RectTransform rect = menuUIObject.GetComponent<RectTransform> ();
		rect.offsetMin = new Vector2 (rect.offsetMin.x, 0);
		rect.offsetMax = new Vector2 (rect.offsetMin.x, menuHeight ());

		OnOpened ();
	}

	public virtual void OnOpened ()
	{

	}


	public void Close ()
	{
		RectTransform rect = menuUIObject.GetComponent<RectTransform> ();
		rect.offsetMin = new Vector2 (rect.offsetMin.x, -menuHeight ());
		rect.offsetMax = new Vector2 (rect.offsetMin.x, 0);
	
		OnClosed ();
	}

	public virtual void OnClosed ()
	{
		
	}



	void ReloadTabsDisplay ()
	{
		RemoveTabsDisplay ();

		//for each tab create one page, one tab button
		int noOfTabs = numberOfTabs ();
		for (int i = 0; i < noOfTabs; i++) {
			int tabIndex = i; //creates a copy of the index 

			#region create tab button
			//create tab button
			GameObject tabButton = GameObject.Instantiate (buttonPrefab, mainTabPanel.transform);
			tabButton.AddComponent<LayoutElement> ();

			//tab button position
			tabButton.GetComponent<RectTransform> ().SetSizeWithCurrentAnchors (RectTransform.Axis.Vertical, tabHeight ());

			//tab button behavior
			Button button = tabButton.GetComponent<Button> ();
			button.onClick.AddListener (delegate {
				DidSelectTab (tabIndex);
			});

			//tab button aesthetics
			Text tabText = tabButton.GetComponentInChildren<Text> ();
			tabText.fontSize = 40;
			tabText.text = titleForTab (tabIndex);
			tabText.color = Color.gray;

			ColorBlock colors = button.colors;
			colors.highlightedColor = themeMid;
			colors.pressedColor = themeBright;
			button.colors = colors;

			//add button to array to keep track
			tabsUIObjects.Add (tabButton);

			#endregion
		}
	}

	void RemoveTabsDisplay ()
	{
		foreach (GameObject go in tabsUIObjects) {
			GameObject.Destroy (go);
		}

		tabsUIObjects.Clear ();
	}

	void ReloadCellsDisplay (int tabIndex)
	{
		RemoveCellsDisplay ();

		for (int x = 0; x < numberOfCellsForTab (tabIndex); x++) {				
			int cellIndex = x; //creates a copy of the index

			//create section panel
			GameObject cell = GameObject.Instantiate (buttonPrefab, mainCellPanel.transform);
			cell.AddComponent<LayoutElement> ();
			cell.GetComponent<Image> ().color = Color.gray;
			cellUIObjects.Add (cell);
			cell.GetComponent<Button> ().onClick.AddListener (delegate {
				DidSelectCell (new Vector2 (cellIndex, tabIndex));
			});


		}
	}

	void RemoveCellsDisplay ()
	{
		foreach (GameObject go in cellUIObjects) {
			Destroy (go);
		}

		cellUIObjects.Clear ();
	}




	void DidSelectTab (int index)
	{				
		//update displays (selects pressed button, deselects all other buttons)
		for (int i = 0; i < tabsUIObjects.Count; i++) {
			Button button = tabsUIObjects [i].GetComponent<Button> ();
			Text tabText = tabsUIObjects [i].GetComponentInChildren<Text> ();				
			ColorBlock colors = button.colors;

			if (i == index) {
				tabText.color = Color.white;
				colors.normalColor = themeMid;
			} else {
				tabText.color = Color.gray;
				colors.normalColor = themeDark;
			}

			button.colors = colors;
		}

		ReloadCellsDisplay (index);

	}

	public virtual void DidSelectCell (Vector2 index)
	{
		
	}




	private void InitUIElement (GameObject go)
	{
		go.AddComponent<CanvasRenderer> ();
		go.AddComponent<Image> ();
	}



	abstract public void Initialize ();

	abstract public int numberOfTabs ();

	abstract public int numberOfCellsForTab (int tabNumber);

	abstract public string titleForTab (int tabNumber);

	abstract public GameObject cellForIndex (Vector2 indexPath);

	public virtual float menuHeight ()
	{
		return 400;
	}

	public virtual float tabHeight ()
	{
		return 65f;
	}
}


