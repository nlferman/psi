using UnityEngine;
using System.Collections;

public class SightRange : MonoBehaviour {
	
	public bool awakeState;
	public bool stopOnLeaveSight;
	
	public float sightRange;
	Vector2 distance;
	
	Rigidbody2D myrigidbody2D;
	PlayerController player;
	
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D>();
		player = FindObjectOfType<PlayerController> ();
	}
	
	void Update () {
		
		distance = myrigidbody2D.position - player.GetComponent<Rigidbody2D>().position;
		
		if (distance.sqrMagnitude < sightRange * sightRange) {
			awakeState = true;
		}
		
		if (stopOnLeaveSight) {
			if (distance.sqrMagnitude > sightRange * sightRange) {
				awakeState = false;
			}
		}
	}
}