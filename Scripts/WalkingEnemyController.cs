using UnityEngine;
using System.Collections;

public class WalkingEnemyController : MonoBehaviour {

	public float moveSpeed;
	public bool moveRight;
	public float sightRange;
	public bool facingRight;
	public bool awakeState;

	Rigidbody2D myrigidbody2D;
	private LevelManager levelManager;

	//Animator anim;

	// Use this for initialization
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D>();
		levelManager = FindObjectOfType<LevelManager> ();

		//anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {

		if (awakeState) {
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

	// Flips the sprite
	void Flip() {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}