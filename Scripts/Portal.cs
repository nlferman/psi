using UnityEngine;
using System.Collections;
/**
 * Portal will transport the player between two or more portals.
 * Portals will transport the player to the position of the child.  In the event
 * that there is no child, the portal will use the root instead.
 */
public class Portal : MonoBehaviour {

	private bool transported = false; //A boolean to mark if the player has transported yet.
	//NOTE: With the push method, the player will not touch the portal, and so the bool is currently not need.
	//Furture versions of this script may redact the push method and use the bool instead.

	public enum push {right, left, up, down}; //An enum to determine the direction the player will be pushed out of.
	public push myPush; //Set the direction in the inspector.

	// Use this for initialization
	void Start () {
			
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//When the player enters the portal...
	void OnTriggerEnter2D (Collider2D c){
		teleportPlayer (c);
		
	}

	//Moves the player's transform to the next portal child.  If no child, moves player to the root portal instead.
	void teleportPlayer (Collider2D c)
	{
		float OFFSETX = 1; //The x "push" default.
		float OFFSETY = 0; //The y "push" default.
		if (myPush == push.left) {
			OFFSETX = -1; //Push the player to the left of the portal.
		}
		else
			if (myPush == push.right) {
				OFFSETX = 1; //Push the player to the right of the portal.
			}
			else
				if (myPush == push.up) {
					OFFSETY = 1; //Push the player above the portal.
					OFFSETX = 0; //Don't push the player left or right.
				}
				else
					if (myPush == push.down) {
						OFFSETY = -1; //Push the player below the portal.
						OFFSETX = 0; //Don't push the player left or right.
					}
					else {
						OFFSETX = 1; //Default behavior is to push the player to the right.
						OFFSETY = 0; //And at the same height of the portal.
					}
		float pointerX; //Variable for the x position of the portal
		float pointerY; //Variable for the y position of the portal
		if (!transported) { //Check if the portal has transported recently
			if (c.name == "Player") { //Check if the object coming in contact is the player
				if (this.gameObject.transform.childCount == 0) { //If this doesn't have a child...
					pointerX = gameObject.transform.root.position.x; //Get the root's x
					pointerY = gameObject.transform.root.position.y; //and y positions.
					c.transform.position = new Vector2 (pointerX + OFFSETX, pointerY + OFFSETY); //Set the player's position
					//Portal p = gameObject.transform.root.GetComponent<Portal> (); //Find the root as a gameObject
					//transported = true; //Set transported to true for this object.
					//p.setTransported (true); //Set transported true for the root.
				}
				else { //If this DOES have a child...
					pointerX = gameObject.transform.GetChild (0).position.x; //Get the child's x
					pointerY = gameObject.transform.GetChild (0).position.y; //and y positions.
					c.transform.position = new Vector2 (pointerX + OFFSETX, pointerY + OFFSETY); //Set the player's position
					//Portal p = gameObject.transform.GetComponentInChildren<Portal> (); //Find the child as a gameObject
					//transported = true; //Set transported to true for this object.
					//p.setTransported (true); //Set the child's transported true.
				}
			}
		}
	}

	//When the player exits the portal
	//NOTE: With the push method, the player will not touch the portal, and so the bool is currently not need.
		//Furture versions of this script may redact the push method and use the bool instead.
	void OnTriggerExit2D (Collider2D c){
		resetPortal (c); //Set the transported bool to false.			
	}

	//Sets the transported bool to false.
	void resetPortal (Collider2D c)
	{
		if (transported) { //If transported is true
			if (c.name == "Player") { //and the collider exiting is the player
				transported = false; //Reset the portal's boolean
			}
		}
	}

	//Set the portal's transported boolean
	public void setTransported (bool t){
		transported = t;
	}

	//Get the portal's current transported boolean
	public bool getTransported (){
		return transported;
	}
}
