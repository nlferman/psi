using UnityEngine;
using System.Collections;

public class StompEnemy : MonoBehaviour {

	// Setting up the script
	//public float bounceVelocity;
	//Rigidbody2D myrigidbody2D;
	
	
	//private int damageToGive = 1;
	
	
	void Start () {
		//myrigidbody2D = GetComponent<Rigidbody2D> ();
	}

	void OnTriggerEnter2D(Collider2D other) {
		
		if (other.tag == "Enemy"  && other.transform.position.y < transform.position.y) {
			Destroy (other.gameObject);  //TODO Change this to deal damage to target, and check if target can be damaged.
			//myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, bounceVelocity);
		}
		
		
		if (other.name == "Player" && other.transform.position.y < transform.position.y){
			//HealthManager.HurtPlayer (damageToGive);  //Needs more testing with invincibility frames.
			Destroy (gameObject);
				
			}
			
	}
			
}
