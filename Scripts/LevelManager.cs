using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {
	
	// Setting up the script
	public GameObject currentCheckpoint;
	PlayerController player;
	public HealthManager healthManager;
	
	public GameObject levelExit;
	
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		healthManager = FindObjectOfType<HealthManager> ();
	}
	
	// Respawns the player, returning to the current checkpoint and giving full health
	public void RespawnPlayer () {
		Debug.Log ("Player Respawn");
		player.transform.position = currentCheckpoint.transform.position;
		healthManager.FullHealth ();
		healthManager.isDead = false;
	}
	
	public void LoadLevel(string name) {
		Application.LoadLevel(name);
	}
}
