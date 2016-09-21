/*Menu Joystick will allow inputs from a controller or keyboard
to be functional with menu based buttons or GUIs.
To use it:  Place it on the Canvas with buttons.
Set the Canvas size to the number of buttons you want the canvas to control.
Set each button in the array in your preferred order of buttons.
NOTE:  This version is only compatible with UP and DOWN Axes.*/

using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.CodeDom;
using System;
using UnityEngine.EventSystems;
using System.Reflection;
using UnityEngine.Networking.Match;
using UnityEditorInternal;

public class MenuJoystick : MonoBehaviour {

	public Button[] b;  //Array for buttons
	private int selected; //Int for currently selected button in array.
	private bool canCall = true; //A bool to help reduce the speed of the active button.
	private bool canMove = false;

	// Use this for initialization
	void Start () {


		//Disables each button except the first button.
		for (int n = 1; n < b.Length; n++) {
			b [n].interactable = false;
			selected = 0;


	}
	}
	
	// Update is called once per frame
	void Update () {


		//Sets the axis read in to Vertical
		float vInput = (float)Input.GetAxis ("Vertical");

		//Listener for the Vertical Axis as well as the canCall bool to slow down rate button changes
		//Starts the button changing Coroutine
		if (Input.GetButton ("Vertical") && canCall && canMove)
			StartCoroutine (selectButton (vInput));

		//Listener for the Submit button, activates the selected button's onClick method.
		if (Input.GetButtonDown ("Submit")) {
			b [selected].onClick.Invoke ();
		}
	
	}

	//Cycles through the buttons.
	IEnumerator selectButton(float i){
		canCall = false; //Will prevent input from the axis for a brief time.

		//Start a try block since there's an error that needs swatting down.
			try {
			//if the axis is negative (down)...
				if (i < 0) {
					selected++; //Increment the selected int.
					wrapSelected ();
					if (selected > 0) //Disable the button that was just hilighted
						b [selected - 1].interactable = false;
					else if (selected <= 0) //Disable the button largest in the array
						b [b.Length - 1].interactable = false;
					b [selected].interactable = true; //Enable the new button
				//If the axis is positive (up)...
				} else if (i > 0) {
					selected--; //Decrement the selected int.
					wrapSelected ();
					if (selected >= 0) //Disable the button that was just hilighted.
						b [selected + 1].interactable = false;
					else if (selected < 0)
						b [b.Length - 1].interactable = false; //Disable the button largest in the array
					b [selected].interactable = true; 
				}
			//Because Unity will freeze if the index becomes negative (despite wrapSelection preventing this)
			//We need an Exception
			} catch (IndexOutOfRangeException e) {
				//Take the button lowest in the array, disable it, and enable the button highest in the array.
				selected = b.Length - 1;
				b [0].interactable = false;
				b [b.Length - 1].interactable = true;
				print (e); 
			}
		//Wait for 1/10 of a second before allowing the next input.
		yield return new WaitForSeconds (0.1f);
		canCall = true;
	}

	//If the button reaches the end of the array, wrap around the the other end of the array.
	void wrapSelected(){
		if (selected < 0) {
			throw new System.IndexOutOfRangeException ();
			//selected = 5;
		}
		else if (selected > b.Length-1)
			selected = 0;
	}

	public void toggleMove(bool move){
		canMove = move;
	}
}