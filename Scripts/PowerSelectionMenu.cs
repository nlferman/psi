using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerSelectionMenu : MonoBehaviour {
	//slots are the x positions of each position for the powers in the power selector UI element
	//EDIT: obsolete, only one power image will be visible at a time
	//private int[] slots;

	//why make these public? you can grab the player and selectorSprite within the script.

	public int powerCount;
	public GameObject player;
	public GameObject selectorObject;

	public GameObject power0fab;
	public GameObject power1fab;
	public GameObject power2fab;
	public GameObject power3fab;
	public GameObject power4fab;


	private SpawnPlatform sP;
	//key bindings
	private KeyCode cycleLeftKey = KeyCode.Q;
	private KeyCode cycleRightKey = KeyCode.E;
	private KeyCode toggleMenuKey = KeyCode.R;
	//currently selected power
	private int curPower;
	//Sprite[] powerSprites = new Sprite[powerCount];
	private GameObject[] powerObjectFabs;
	//the scripts for each power
	//GameObject[] powerScripts = new GameObject[powerCount];
	//flag for if menu is visilbe
	bool isVisible = true;


	/* don't want to use, can't set the transform of a sprite, it's not a GameObject
	public Sprite sprite0;
	public Sprite sprite1;
	public Sprite sprite2;
	public Sprite sprite3;
	public Sprite sprite4;
	*/


	// Use this for initialization
	void Start () {
		//see above, slots is obsolete
		/*slots = new int[powerCount];
		for (int i = 0; i < powerCount; i++)
			slots [i] = i * -100;
*/

		sP = GetComponent<SpawnPlatform> ();
		curPower = 0;
		powerObjectFabs = new GameObject[powerCount];
		//adds the textures for each power
		//will be modified as powers are added so that the sprite will be pulled directly from the power rather than loaded

		loadPowers ();		

		GameObject firstReal = Instantiate(powerObjectFabs [0]);
		firstReal.SetActive(false);
		sP.setRealPlatform (firstReal);


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

		/*This loop should be unnessecary, object properties are in the prefabs.
		for(int i = 0; i < powerCount; i++) {
			/*
			//add spri	tes to gameObjects so they can be rendered on screen
			GameObject powerObject = powerObjects[i];
			powerObject.AddComponent<Image>();
			Image image = powerObject.GetComponent <Image> ();

			//edit John R
			//GameObject powerObject = Instantiate (powerObjectFabs[i]) as GameObject;
			//Image image = powerObject0.AddComponent<Image>();
			//image.sprite = powerObjects [i].GetComponent <Image> ().sprite;
			///end edit

			//image.sprite = powerObject.GetComponent <SpriteRenderer> ().sprite;
			//make the PowerSelectionMenu the parent of the power

			//powerObjects[i].transform.SetParent (selectorObject.transform);
			//powerObjects [i].transform.localPosition = powerPosition;
			//posistion the powerSprite relavitve to PowerSelectionMenu
			//powerObject.transform.localPosition = powerPosition;
			//only showing one power at a time:
			//powerPosition.x -= 100;
			//adjust the scale of each sprite
			//powerObjects[i].transform.localScale = new Vector3(1f, 1f, 1f);
			//add to the array of powerObjects
		}
		*/

		//sP.setRealPlatform (powerObjects [0]);
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

		//cycle selector left
		if(Input.GetKeyDown(cycleLeftKey)){
			cyclePowers(true);
		}
		//cycle selector right
		if(Input.GetKeyDown(cycleRightKey)){
			cyclePowers(false);
		}
	}
	void cyclePowers(bool isLeft){
		//disable current power
		//TODO
		//cycle to the left
		if (isLeft) {
			if (curPower - 1 < 0) {
				curPower = powerCount - 1;
			} else {
				curPower = curPower - 1;
			}
			//sets sprite of selectorObject
			selectorObject.GetComponent <SpriteRenderer> ().sprite = powerObjectFabs [curPower].GetComponent <SpriteRenderer> ().sprite;

			//cycle to the right 
		}else{
			if (curPower + 1 > powerCount - 1) {
				curPower = 0;
			} else {
				curPower = curPower + 1;
			}
			//sets sprite of selectorObject
			selectorObject.GetComponent <SpriteRenderer> ().sprite = powerObjectFabs [curPower].GetComponent <SpriteRenderer> ().sprite;
		}


		sP.setRealPlatform (Instantiate(powerObjectFabs [curPower]));
	}

	/*
	 //invert the vissiblity
	isVisible = !isVisible; what even is this?
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
		selectorObject.SetActive(false);
	}

	void loadPowers ()
	{
		if (powerCount >= 1)
			powerObjectFabs [0] = power0fab;
		if (powerCount >= 2)
			powerObjectFabs [1] = power1fab;
		if (powerCount >= 3)
			powerObjectFabs [2] = power2fab;
		if (powerCount >= 4)
			powerObjectFabs [3] = power3fab;
		if (powerCount >= 5)
			powerObjectFabs [4] = power4fab;
	}

	void toggleMenuOn(){
		selectorObject.SetActive (true);
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