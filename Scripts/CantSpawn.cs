using UnityEngine;
using System.Collections;

public class CantSpawn : MonoBehaviour {

	private bool cantspawn = false;
	private SpriteRenderer sR;
	private float alphaNum;
	// Use this for initialization
	void Start () {
		sR = GetComponent<SpriteRenderer> ();
		alphaNum = sR.color.a;
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter2D (Collider2D other) {
		cantspawn = true;
		setColorRed ();
	}

	void OnTriggerStay2D (Collider2D other) {
		cantspawn = true;
		setColorRed ();
	}

	void OnTriggerExit2D (Collider2D other) {
		cantspawn = false;
		setColorWhite ();
	}

	public bool getCantSpawn (){
		return cantspawn;
	}

	void setColorRed () {
		sR.color = new Color (1, 0, 0, alphaNum);
	}
	void setColorWhite () {
		sR.color = new Color (1, 1, 1, alphaNum);
	}
}
