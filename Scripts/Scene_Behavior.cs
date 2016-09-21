using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Scene_Behavior : MonoBehaviour {



private bool hasMoved = false;
private Animator anim;

	// Use this for initialization
	void Start () {
	anim = gameObject.GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D collider){
		
			if (!hasMoved && collider.name == "Player"){
			anim.SetTrigger("MoveTrigger");
			hasMoved = true;
			}
	}
}
