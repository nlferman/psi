using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SetMenu : MonoBehaviour {

	//public object references
	public Canvas panel0, panel1, panel2, panel3;
	public Text settingName;

	//private variables
	//array of strings for settings panel names
	private string[] settingPanel = {	"Gameplay", 			//gameplay, difficulty, control sensitivity, etc.
										"Sound", 				//music, sound effects, and voiceover volume
										"Visual", 				//screen brightness, resolution
										"Miscellaneous"};		//anything else that doesn't fit in the other categories

	private int activeSettings = 0;								//integer for tracking currently viewed settings panel

	// Use this for initialization
	void Start () {
		initSettings ();					//initialize the settings menu to default values
	}
	//initialize the settings menu to default values
	public void initSettings(){
		activeSettings = 0;					//start on panel 0
		enablePanel (activeSettings);		//update visible settings
	}

	// Update is called once per frame
	void Update () {
		//do nothing currently
	}

	//move to the next panel
	//called by Next Menu button
	public void nextPanel(){
		//checks if visible panel is at the end and...
		if (activeSettings == 3) 
			activeSettings = 0;				//...loops back to the stat
		else
			activeSettings++;				//...increments to the next value

		enablePanel (activeSettings);		//update visible settings
	}

	//move to the previous panel
	//called by Previous Menu button
	public void prevPanel(){
		//checks if visible panel is at the start and...
		if (activeSettings == 0) 
			activeSettings = 3;				//...loops around to the end
		else
			activeSettings--;				//...increments to the previous value

		enablePanel (activeSettings);		//update visible settings
	}

	public void settingsDone(){
		//does nothing right now
		//this function will eventually call the game controller 
		//to configure high level settings prior to loading the game
	}

	//enable and display the appropriate settings panel to the player
	//input is the number index of the panel to be displayed
	void enablePanel(int num){
		//first turn all the panels off, currently unnecessary as all panels are blank
		//disableAll ();

		//then switch to the new panel based on input, currently unnecessary as all panels are blank
		/*switch (num) {
		case 0:
			panel0.enabled = true;
			break;
		case 1:
			panel1.enabled = true;
			break;
		case 2:
			panel2.enabled = true;
			break;
		case 3:
			panel3.enabled = true;
			break;
		}*/

		//update the text box with the correct panel name
		settingName.text = settingPanel [activeSettings];
	}

	//disables all applicable panels to allow a fresh display of options
	void disableAll(){
		panel0.enabled = false;
		panel1.enabled = false;
		panel2.enabled = false;
		panel3.enabled = false;
	}
}
