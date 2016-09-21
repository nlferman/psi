using UnityEngine;
using System.Collections;

public class JournalController : MonoBehaviour {



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	//For now the journal will disappear and print a message to the console.
	void OnTriggerEnter2D (Collider2D other){
		if (other.name == "Player") {
			print ("Journal page collected.");
			Destroy (gameObject);
		}		
	}
}
