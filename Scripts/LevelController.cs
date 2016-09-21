using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LevelController : MonoBehaviour {

	//Public Objects
	public Canvas pauseMenu;							//the pause menu UI element

	//Private Variables
	private bool paused;								//paused state of the game true - game is paused, false - game is not paused
	private string MainMenu = "MainMenu";				//name of the "main menu" scene
	private int mainMenu = 0;							//number of the "main menu" scene

	//Self-referential Variables
	GameObject me;										//reference to self
	// Use this for initialization
	// sets default level behavior
	void Start () {
		Unpause ();										//calls Unpause function - resumes normal game behavior
		paused = false;									//initializes paused state to FALSE - not paused
		me = GameObject.Find ("GO - LevelControl");		//gets reference to level control game object in the loaded level
	}
	
	// Update is called once per frame
	void Update () {
		//check input to pause game...
		if (Input.GetKeyDown (KeyCode.Escape))
			TogglePause ();				//...calls function which toggles pause state of game

		//check pause state now that the game state has changed...
		if (paused)
			Pause ();					//...paused is true - meaning the game was JUST paused
		else
			Unpause ();					//...paused is false - meaning the game was JUST unpaused
	}

	//private function which enacts paused state
	void Pause() {
		pauseMenu.enabled = true;	//enables the pause menu UI element, making it visible
		Time.timeScale = 0f;		//freezes the game
	}

	//private function which enacts unpaused state
	void Unpause () {
		pauseMenu.enabled = false;	//disables the pause menu UI element, making it invisible
		Time.timeScale = 1f;		//unfreezes the game
	}

	//public function used to toggle the games paused state
	//called from 'Resume' button on Pause Menu and internally to this script
	public void TogglePause() {
		paused = !paused;			//inverts boolean variable 'paused'
	}

	//public function used to restart the current level from the beginning
	//does not preserve any data
	//called from 'Restart' button on Pause Menu
	public void RestartLevel() {
		Application.LoadLevel (Application.loadedLevelName);	//reloads/restarts the current level
	}

	//public function used to quit the level and return to the main menu
	//preserves data through OnLevelWasLoaded function
	//called from 'Main Menu' button on Pause Menu
	public void ExittoMain() {
		GameObject.DontDestroyOnLoad (me);		//prevent destruction of this object on returning to main menu

		//check if game is paused
		if (paused) 							//toggle paused value to ensure game is unpaused...
			TogglePause ();						//...unnecessary for main menu but good practice

		Application.LoadLevel (MainMenu);		//loads the Main Menu scene
	}

	//special private function called once a new level has been loaded
	//note this is necessary to load all the objects in the new level before trying to access them from an undestroyed object
	//input - 'level' of type int, represents the index value of the newly loaded level
	void OnLevelWasLoaded(int level)
	{
		//check if the main menu was just loaded
		if (level != mainMenu)
			return;												//if not, exit out of the function

		GameObject mC = GameObject.Find ("MenuController");		//get a GO reference to the menu controller of the main menu
		
		//check if the menu controller exists...
		if (mC != null)
			mC.GetComponent<SwapMenu> ().LevelData ();			//...and call a public function to transfer level data
			//currently there is no level data to transfer but the script framework is in place
		else
			Debug.Log ("Can't find the MenuController");		//...and alert the console of the issue
		
		GameObject.DestroyImmediate (me);						//destroy the level controller object now that its job is done
	}
}
