using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameController : MonoBehaviour {

	//private variables
	private int MAIN_MENU = 0, 			//constant variable for calling main menu, should always be Level 0
				TUTORIAL_LEVEL = 9;		//constant variable for calling tutorial, should always be the Last Level
	//private array for level names
	private string[] Level = {	"MainMenu",
								"Level01",
								"Level02",
								"Level03", 
								"Level04", 
								"Level05", 
								"Level06", //dummy values for the remaining 3 levels
								"Level07", //dummy values for the remaining 3 levels
								"Level08", //dummy values for the remaining 3 levels
								"TutorialLevel"};

	// Use this for initialization
	void Start () {
		//currently this option is not needed
		//GameController.DontDestroyOnLoad (this);
		//revisit once game settings and difficulty options are available
	}
	
	// Update is called once per frame
	void Update () {
		//do nothing
	}

	//called once the player confirms they want to quit the game and exit the application
	public void confirmQuit() {
		//calls the function to do just that
		QuitGame ();
	}

	//quits the game
	private void QuitGame(){
		Application.Quit ();
		Debug.Log ("Quitting...");
	}

	//loads a particular level
	//input is an integer representing the index of the level to be loaded
	public void loadLevel(int num) {
		//first check if the index called actually exists as a level
		if (Level [num].Equals (null))
			return;	//if it doesn't, don't try and load it

		//load the appropriate and loadable level by Level Name
		Application.LoadLevel(Level[num]);
	}

	//take the player back to the main menu
	public void mainMenu () {
		Application.LoadLevel (MAIN_MENU);
	}

	//take the player to the tutorial level
	public void loadTutorial () {
		//this may eventually be unnecessary depending on game layout
		Application.LoadLevel (TUTORIAL_LEVEL);
	}

	//currently this method is unnecessary as the levels have a separate controller to handle such things
	/*public void reloadLevel() {
		Application.LoadLevel (Application.loadedLevelName);
	}*/

	//currently this method does nothing, but eventually will be used to collect updated level information and statistics 
	//as the player completes the diary and beats more missions
	public void passLevelData() {
		//placeholder output to ensure method called
		Debug.Log("saving data...");
	}
}
