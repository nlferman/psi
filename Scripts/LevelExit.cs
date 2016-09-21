using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LevelExit : MonoBehaviour {

	private LevelManager levelManager;
	private PlayerController player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D (Collider2D collider){
		if (collider.name == "Player"){
			levelManager = GameObject.FindObjectOfType<LevelManager>();
			levelManager.LoadLevel("LevelSelect");
		}
	}
}
