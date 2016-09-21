using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	// Setting up the player
	Rigidbody2D myrigidbody2D;
	
	// Setting up movement
	public float moveSpeed;
	public bool facingRight = true;
	
		
	// Setting up jumping and falling
	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.1f;
	public LayerMask whatIsGround;
	public float jumpHeight;
	bool canDoubleJump = true;

	// Setting up platform spawning
	public bool spawningPlat;
    public bool canMove = true;
	// Setting up animations
	private Animator anim;
	public bool isHurt;
	public float clipLength;
    public bool jumped;

	public float slopeFriction;
	
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
		}

	
	void FixedUpdate () {
		
		// Checks if the player character is grounded
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool ("Ground", grounded);
        //anim.SetFloat ("vSpeed", myrigidbody2D.velocity.y);

        if (grounded)
        {
            canDoubleJump = true;         
        }

        // Character movement
        if (canMove) {
            float move = Input.GetAxis("Horizontal");
            anim.SetFloat ("isWalking", Mathf.Abs (move));


            // REPLACE WITH UNITY INPUT ASAP
            //if (Input.GetButton("Walk"))
            //myrigidbody2D.velocity = new Vector2 (move * moveSpeed / 3, myrigidbody2D.velocity.y);
            //else
            myrigidbody2D.velocity = new Vector2((move * moveSpeed) * Time.deltaTime, myrigidbody2D.velocity.y);
            
            
		// Flips the sprite if the character is facing left
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
		}

		NormalizeAllSlopes ();
		// Character attack
		//if (anim.GetBool("Attack"))
			//anim.SetBool("Attack", false);
		
		//if (Input.GetButtonDown ("Attack")) {
			
			//anim.SetBool("Attack", true);
		//}
	}
	
	void Update () {

		// Jump and double jump
		if ((grounded || canDoubleJump) && canMove && Input.GetButtonDown ("Jump")) {

            
            myrigidbody2D.velocity = new Vector2 (myrigidbody2D.velocity.x, jumpHeight);


			if (!grounded) {
				anim.SetBool ("Ground", false);
			}

			if (canDoubleJump && !grounded)
				canDoubleJump = false;

            //jump aimation
            //anim.SetTrigger("jump");
        }

        if(grounded)
            //stopping jumping animation

            anim.SetBool ("Ground", true);
    }

	// Flips the sprite
	public void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	// Determines if the player is trying to spawn a platform
	public void setSpawningPlat (bool s) {
		spawningPlat = s;
	}
	
	public void Damaged () {
		if (isHurt){
			anim.SetTrigger ("isDamaged");
			myrigidbody2D.velocity = new Vector2 (-2f, 1f);
			//TODO delay for the clip length of "Player_Damaged". then set isHurt to false;
		}
	}

    
	void OnCollisionEnter2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform" && transform.position.y > other.transform.position.y) {
			transform.parent = other.transform;
		}


	}
	
	void OnCollisionExit2D (Collision2D other) {
		if (other.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}


	}
	void NormalizeAllSlopes () {

				// Attempt vertical normalization

		 	 if (grounded) {

						RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, 1f, whatIsGround);



						if (hit.collider != null && Mathf.Abs(hit.normal.x) > 0.1f) {

								Rigidbody2D body = GetComponent<Rigidbody2D>();

								// Apply the opposite force against the slope force 

								// You will need to provide your own slopeFriction to stabalize movement

								body.velocity = new Vector2(body.velocity.x - (hit.normal.x * slopeFriction), body.velocity.y);


								//Move Player up or down to compensate for the slope below them

								Vector3 pos = transform.position;

								pos.y += -hit.normal.x * Mathf.Abs(body.velocity.x) * Time.fixedDeltaTime * (body.velocity.x - hit.normal.x > 0 ? 1 : -1);

								transform.position = pos;

							}

					}

			}
}
