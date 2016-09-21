using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEditor;

public class SwapMenu : MonoBehaviour {

	//public UI elements - naming convention is clear
	public Canvas 	mainMenu, 			
					settingsMenu, 
					loadMenu, 
					quitMenu, 
					logbookMenu;
					

	private MenuJoystick[] menuj;

	// Use this for initialization
	void Start () {
		menuj = Object.FindObjectsOfType (typeof(MenuJoystick)) as MenuJoystick[];
		for (int i = 0; i < menuj.Length; i++)
			print (menuj[i].transform.name);

		disableAllMenu ();		//call function to turn off all menus
		MainMenu ();			//call function to enable only main menu on startup

		/*
		Quit 0
		Main 1
		Load 2
		Settings 3
		Diary 4	
		*/
		 
	}
	
	// Update is called once per frame
	void Update () {
		//check for escape key when main menu is enabled and load/settings menus are NOT enabled and...
		if ((Input.GetKeyDown (KeyCode.Escape)) && (mainMenu.isActiveAndEnabled) && ((!loadMenu.isActiveAndEnabled)&&(!settingsMenu.isActiveAndEnabled))) {	
			Quit ();			//...bring up the quit menu
		//check for escape key when loading or settings menus are enabled
		} else if ((Input.GetKeyDown (KeyCode.Escape)) && ((loadMenu.isActiveAndEnabled)||(settingsMenu.isActiveAndEnabled))) {
			disableAllMenu (); 	//call function to turn off all menus
			MainMenu ();		//call function to enable only main menu on startup
		}
		//else do nothing;
	}

	//public function which disables and enables the visible menu UI when called
	//input - 'action' of type string - is the name of the desired menu
	public void ChangeMenu(string action){
		disableAllMenu ();		//call function to turn off all menus

		//determine desired menu...
		switch (action) 
		{
			//...and call appropriate function......
			case "quit":				
				Quit ();		
				break;
			case "main":
				MainMenu ();
				break;
			case "settings":
				Settings();
				break;
			case "load":
				Load ();
				break;
			case "logbook":
				Logbook();
				break;
			//...and do nothing else
			default:
				break;
		}
	}

	//disables and enables the quit menu as desired
	//handles the main menu in the background to ensure consistent behavior
	void Quit(){
		//check if quit menu is currently enabled and...
		if (quitMenu.isActiveAndEnabled) {
			//...keep main menu enabled and disable quit menu
			mainMenu.enabled = true;
			quitMenu.enabled = false;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (true);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		} else {
			//...enable both main and quit menus
			mainMenu.enabled = true;
			quitMenu.enabled = true;
			menuj [0].toggleMove (true);
			menuj [1].toggleMove (false);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		}
	}

	//toggles main menu when necessary
	void MainMenu(){
		if (mainMenu.isActiveAndEnabled) {
			mainMenu.enabled = false;
			menuj [1].toggleMove (false);
		} else {
			mainMenu.enabled = true;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (true);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		}
	}

	//disables and enables the settings menu as desired
	//handles the main menu in the background to ensure consistent behavior
	void Settings(){
		//check if settings menu is currently enabled and...
		if (settingsMenu.isActiveAndEnabled) {
			//...keep main menu enabled and disable settings menu
			mainMenu.enabled = true;
			settingsMenu.enabled = false;
			menuj [1].toggleMove (true);
		} else {
			//...enable both main and settings menus
			mainMenu.enabled = true;
			settingsMenu.enabled = true;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (false);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (true);
			menuj [4].toggleMove (false);
		}
	}

	//disables and enables the loading menu as desired
	//handles the main menu in the background to ensure consistent behavior
	void Load(){
		//check if loading menu is currently enabled and...
		if (loadMenu.isActiveAndEnabled) {
			//...keep main menu enabled and disable loading menu
			mainMenu.enabled = true;
			loadMenu.enabled = false;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (true);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		} else {
			//...enable both main and loading menus
			mainMenu.enabled = true;
			loadMenu.enabled = true;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (false);
			menuj [2].toggleMove (true);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		}
	}

	//toggles diary menu when necessary
	void Logbook(){
		if (logbookMenu.isActiveAndEnabled) {
			mainMenu.enabled = true;
			logbookMenu.enabled = false;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (true);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (false);
		} else {
			mainMenu.enabled = true;
			logbookMenu.enabled = true;
			menuj [0].toggleMove (false);
			menuj [1].toggleMove (false);
			menuj [2].toggleMove (false);
			menuj [3].toggleMove (false);
			menuj [4].toggleMove (true);
		}
	}
		

	//this function disables all menus to ensure a fresh background when enabling others
	void disableAllMenu(){
		mainMenu.enabled = false;
		settingsMenu.enabled = false;
		loadMenu.gameObject.SetActive (false);
		quitMenu.enabled = false;
		logbookMenu.enabled = false;

		menuj [0].toggleMove (false);
		menuj [1].toggleMove (true);
		menuj [2].toggleMove (false);
		menuj [3].toggleMove (false);
		menuj [4].toggleMove (false);

		//there is no dreamland menu currently so this line is unused 
		//...but included for purposes of consistency
		//dreamlandMenu.enabled = false;
	}

	//public function used to transfer level data from a returning level controller to the game controller
	//currently there is no data to transfer but this function is here as a placeholder
	public void LevelData() {
		Debug.Log ("saving level data...");
	}
}
