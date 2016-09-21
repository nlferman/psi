using UnityEngine;
using System.Collections;

public class WallCollisionReverseDirection : MonoBehaviour {
	

	private WalkingEnemyController wec;
	Rigidbody2D myrigidbody2D;
	PlayerController player;
	private LevelManager levelManager;

	void Start () {
		wec = FindObjectOfType<WalkingEnemyController> ();
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		player = FindObjectOfType<PlayerController> ();
		levelManager = FindObjectOfType<LevelManager> ();
	}

	// Reverse directions when colliding with an object to the side
	void OnTriggerEnter2D(Collider2D other) {
		wec.moveRight = !wec.moveRight;
	}
}