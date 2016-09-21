// THIS SCRIPT NEEDS TO BE REVISED
// DO NOT USE

using UnityEngine;
using System.Collections;

public class RedEnemyController : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public float sightRange;

	bool facingRight = false;

	Vector2 distance;

	PlayerController player;

	public LevelManager levelManager;

	// Setting up animations
	Animator anim;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();

		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (player.GetComponent<Rigidbody2D>().position.x > GetComponent<Rigidbody2D>().position.x)
			moveRight = true;
		else
			moveRight = false;

		var heading = GetComponent<Rigidbody2D>().position - player.GetComponent<Rigidbody2D>().position;
		var distance = heading.magnitude;
		//var direction = heading / distance;

		distance = Vector2.Distance (player.GetComponent<Rigidbody2D>().transform.position, GetComponent<Rigidbody2D>().transform.position);

		if (heading.sqrMagnitude < sightRange * sightRange) {
			if (moveRight)
				GetComponent<Rigidbody2D>().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
			else
				GetComponent<Rigidbody2D>().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}

		anim.SetFloat ("Speed", Mathf.Abs (GetComponent<Rigidbody2D>().velocity.x));

		// Flips the sprite if the character is facing left
		if (GetComponent<Rigidbody2D>().velocity.x > 0 && !facingRight)
			Flip ();
		else if (GetComponent<Rigidbody2D>().velocity.x < 0 && facingRight)
			Flip ();
	}

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
