using UnityEngine;
using System.Collections;

public class EnemyMentalController : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public float sightRange;
	
	public bool facingRight;
	
	Vector2 distance;
	
	Rigidbody2D myrigidbody2D;
	PlayerController player;
	
	private LevelManager levelManager;
	
	// Setting up animations
	//Animator anim;
	
	// Use this for initialization
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();
		
		//anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		var heading = myrigidbody2D.position - player.GetComponent<Rigidbody2D>().position;
		var distance = heading.magnitude;
		//var direction = heading / distance;
		
		distance = Vector2.Distance (player.GetComponent<Rigidbody2D>().transform.position, myrigidbody2D.transform.position);
		
		if (heading.sqrMagnitude < sightRange * sightRange) {
			if (moveRight)
				myrigidbody2D.velocity = new Vector2 (moveSpeed, myrigidbody2D.velocity.y);
			else
				myrigidbody2D.velocity = new Vector2 (-moveSpeed, myrigidbody2D.velocity.y);
		}
		
		//anim.SetFloat ("Speed", Mathf.Abs (myrigidbody2D.velocity.x));
		
		// Flips the sprite if the character is facing left
		if (myrigidbody2D.velocity.x < 0 && !facingRight)
			Flip ();
		else if (myrigidbody2D.velocity.x > 0 && facingRight)
			Flip ();
	}
	
	// FIX TO GIVE DAMAGE TO PLAYER
	//Hurt Player on Contact script already does this.  Please remove.
	void OnTriggerEnter2D(Collider2D other) {
		if (other.name == "Player") {
			//levelManager.RespawnPlayer();
		}
	}
	
	// Flips the sprite
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}