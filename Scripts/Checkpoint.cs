using UnityEngine;
using System.Collections;

public class Checkpoint : MonoBehaviour {

	// Setting up the script
	public LevelManager levelManager;
	
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	// When the player collides with an object with this script attached,
	// that object becomes the current checkpoint
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player") {
			Debug.Log ("Activated Checkpoint " + transform.position);
			levelManager.currentCheckpoint = gameObject;
		}
	}
}
