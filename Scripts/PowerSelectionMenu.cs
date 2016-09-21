using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerSelectionMenu : MonoBehaviour {
	//why make these public? you can grab the player and selectorSprite within the script.
	public GameObject player;
	public GameObject selectorSprite;

	/*obselete
	public Sprite sprite0;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	*/

	public GameObject power0;
	public GameObject power1;
	public GameObject power2;
	public GameObject power3;
	public GameObject power4;

	//key bindings
	private KeyCode cycleLeftKey = KeyCode.Q;
	private KeyCode cycleRightKey = KeyCode.E;
	private KeyCode toggleMenuKey = KeyCode.R;
	//currently selected power
	private int curPower = 0;
	const int POWER_COUNT = 5;  //Consider making this a variable
	//leftmost power in menu
	private int leftMostPower = POWER_COUNT - 1;
	//Sprite[] powerSprites = new Sprite[POWER_COUNT];
	GameObject[] powerObjects = new GameObject[POWER_COUNT];
	//the scripts for each power
	//GameObject[] powerScripts = new GameObject[POWER_COUNT];
	//flag for if menu is visilbe
	bool isVisible = true;
	// Use this for initialization
	void Start () {
		//adds the textures for each power
		//will be modified as powers are added so that the sprite will be pulled directly from the power rather than loaded
		powerObjects [0] = power0;
		powerObjects [1] = power1;
		powerObjects [2] = power2;
		powerObjects [3] = power3;
		powerObjects [4] = power4;

		Vector3 powerPosition = Vector3.zero;
		//Just attatch the sprites and scripts to the object itself, doing it in a script makes no sense
		/*
		//adds the corresponding sprites to the powerObjects
		powerObjects [0] = setPowerSprite (powerObjects [0], sprite0);
		powerObjects [1] = setPowerSprite (powerObjects [1], sprite1);
		powerObjects [2] = setPowerSprite (powerObjects [2], sprite2);
		powerObjects [3] = setPowerSprite (powerObjects [3], sprite3);
		powerObjects [4] = setPowerSprite (powerObjects [4], sprite4);
		*/

		for(int i = 0; i < POWER_COUNT; i++){
			//add sprites to gameObjects so they can be rendered on screen
			GameObject powerObject = powerObjects[i];
			Image image = powerObject.AddComponent<Image>();
			image.sprite = powerObjects [i].GetComponent <SpriteRenderer> ().sprite;
			//make the PowerSelectionMenu the parent of the power
			powerObject.transform.SetParent(this.transform);
			//posistion the powerSprite relavitve to PowerSelectionMenu
			powerObject.transform.localPosition = powerPosition;
			powerPosition.x -= 50;
			//adjust the scale of each sprite
			powerObject.transform.localScale = new Vector3(1f, 1f, 1f);
			//add to the array of powerObjects
			powerObjects[i] = powerObject;
		}


		//assigning a power script to power
		//add the spawn platform script to the first power

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(toggleMenuKey)){
			if(isVisible){
				toggleMenuOff();
			}else{
				toggleMenuOn();
			}
			return;
		}
		//cylce selector right
		if(Input.GetKeyDown(cycleRightKey)){
			cyclePowers(false);
		}
		//cylce selector left
		if(Input.GetKeyDown(cycleLeftKey)){
			cyclePowers(true);
		}
	}
	void cyclePowers(bool isLeft){
		//disable current power
		//TODO
		//cycle to the left
		if(isLeft){
			foreach(GameObject g in powerObjects){
				//shift each position in the right direction
				g.transform.position += new Vector3(-50, 0, 0);
			}
			//moves the leftmost power to the far right
			powerObjects[leftMostPower].transform.position += new Vector3(50 * POWER_COUNT, 0, 0);
			// if the next leftmost power is less then zero use the max else use the normal decrement
			leftMostPower = leftMostPower - 1 < 0 ? POWER_COUNT - 1 : leftMostPower - 1;
			curPower = curPower - 1 < 0 ? POWER_COUNT - 1 : curPower - 1;
			//cycle to the right
		}else{
			foreach(GameObject g in powerObjects){
				//shift each position in the right direction
				g.transform.position += new Vector3(50, 0, 0);
			}
			//moves the rightmost power to the far left
			powerObjects[curPower].transform.position += new Vector3(-50 * POWER_COUNT, 0, 0);
			//set the current power as the leftmost
			leftMostPower = curPower;
			//leftMostPower = leftMostPower + 1 >= POWER_COUNT - 1 ? 0 : leftMostPower + 1;
			curPower = curPower + 1 > POWER_COUNT - 1 ? 0 : curPower + 1;
		}
	}

	/*
	 //invert the visiblity
	isVisible = !isVisible;
	//disable each powerObject so it no longer renders
	foreach(GameObject g in powerObjects){
		g.SetActive(isVisible);
	}
	//disable the selector
	selectorSprite.SetActive(isVisible);
	* */
	void toggleMenuOff(){
		//selectorSprite
		//make the sprites invisible
		foreach(GameObject g in powerObjects){
			g.SetActive(false);
		}
		powerObjects[curPower].SetActive(true);
		isVisible = false;
	}
	void toggleMenuOn(){
		foreach(GameObject g in powerObjects){
			g.SetActive(true);
		}
		isVisible = true;
	}
	/* obselete
	GameObject setPowerSprite(GameObject powerObject, Sprite sentSprite){
		Vector3 powerPosition = Vector3.zero;
		//add sprites to gameObjects so they can be rendered on screen
		Image image = powerObject.AddComponent<Image> ();
		image.sprite = sentSprite;
		//make the PowerSelectionMenu the parent of the power
		powerObject.transform.SetParent (this.transform);
		//posistion the powerSprite relavitve to PowerSelectionMenu
		powerObject.transform.localPosition = powerPosition;
		powerPosition.x -= 50;
		//adjust the scale of each sprite
		powerObject.transform.localScale = new Vector3 (0.4f, 0.2f, 0.4f);
		//add to the array of powerObjects
		return powerObject;
	}
	*/
}