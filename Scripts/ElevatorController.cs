using UnityEngine;
using System.Collections;

public class ElevatorController : MonoBehaviour {
	private Animator anim;
	
	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
		if (collider.name == "Player"){
			anim.SetBool("isMoving", true);
		}
	}
}
