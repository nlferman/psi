using UnityEngine;
using System.Collections;

public class HurtPlayerOnContact : MonoBehaviour {

	// Setting up the script
	public int damageToGive;
	private HealthManager healthManager;

	void Start () {
		healthManager = FindObjectOfType<HealthManager> ();
	}

	// On collision, give the player a set amount of damage
	void OnTriggerEnter2D (Collider2D other) {
		if (other.name == "Player") {	
			HealthManager.HurtPlayer (damageToGive);
		}
	}
}
