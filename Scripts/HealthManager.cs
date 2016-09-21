using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour {

	// Setting up the script
	public int maxPlayerHealth;
	[Range (0, 5)]public static int playerHealth;
	public bool isDead;
	
	private LevelManager levelManager;
	private static PlayerController playerController;
	public Slider healthBar;
	
	void Start () {
		playerHealth = maxPlayerHealth;
		playerController = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();
		healthBar = GetComponent<Slider> ();
		isDead = false;
		
	}
	
	void Update () {

		// Checks to see if the player is dead
		// If the player is dead, respawn
		if (playerHealth <= 0 && !isDead) {
			playerHealth = 0;
			isDead = true;
			levelManager.RespawnPlayer ();
		}

		// The health bar slider shows the player's current health
		healthBar.value = playerHealth;
	}

	// Gives the player a specified amount of damage
	public static void HurtPlayer (int damageToGive) {
		playerHealth -= damageToGive;
		playerController.isHurt = true;
		playerController.Damaged();
		
	}

	// Returns the player to full health
	public void FullHealth () {
		playerHealth = maxPlayerHealth;
	}
}
