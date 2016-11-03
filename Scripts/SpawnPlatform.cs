using UnityEngine;
using System.Collections;

public class SpawnPlatform : MonoBehaviour {

	// Setting up the script
	public GameObject ghostPlat;
	public float spawnDist, platMoveSpeed;
	private GameObject ghost, real, previous;
	private Animator anim;

	private bool spawningPlat = false;

	private PlayerController pM;
	Rigidbody2D myrigidbody2D;
	//private BoxCollider2D bC;
	private Vector3 spawnPoint;
	
	void Start () {
		myrigidbody2D = GetComponent<Rigidbody2D> ();
		pM = GetComponent<PlayerController> ();
		anim = GetComponent<Animator>();
		//bC = GetComponent<BoxCollider2D> ();
		spawnPoint = new Vector3 (spawnDist, 0f, 0f);
	}
	
	// Update is called once per frame
	void Update () {
		// REPLACE WITH UNITY INPUT ASAP
		if ((Input.GetKeyDown (KeyCode.Z)) && (!spawningPlat) && (pM.grounded)) { // Was the intent here to only allow platform spawning when grounded?
			spawningPlat = true;
            pM.canMove = false;
			myrigidbody2D.velocity = new Vector2(0f, 0f);
			anim.SetBool ("isFocusing", true);
			showGhostPlatform ();
		} else if (Input.GetKeyUp (KeyCode.Z)) {
			anim.SetBool ("isFocusing", false);
			DespawnPlat ();
		}

		pM.setSpawningPlat(spawningPlat);

		if (spawningPlat)
			moveGhost ();
	}

	// If the platform cannot spawn at that location, destroy it immediately
	public void DespawnPlat () {
		spawningPlat = false;
		if (ghost.GetComponent<CantSpawn>().getCantSpawn())
			GameObject.DestroyImmediate (ghost, true);	
		else
			spawnRealPlatform ();
        pM.canMove = true;
	}

	void showGhostPlatform(){
		if (ghost != null) 
			GameObject.DestroyImmediate (ghost, true);		

		if (pM.facingRight) {
			ghost = Instantiate (ghostPlat, transform.position + spawnPoint, transform.rotation) as GameObject;
			initialPointX = transform.position.x + spawnDist;
		} else {
			ghost = Instantiate (ghostPlat, transform.position - spawnPoint, transform.rotation) as GameObject;
			initialPointX = transform.position.x - spawnDist;
		}
		initialPointY = transform.position.y;
	}

	void spawnRealPlatform() {
		print ("first line of spawnRealPlatform, real exists?" + real != null);
//		if (previous != null) {
//			GameObject.DestroyImmediate (previous);
//		}
		//if(real != null)
			real.SetActive (true);
		print (ghost.transform.position.ToString());
		real.transform.position = (ghost.transform.position);
		ghost.SetActive (false);
	}

	public float bound;
	private float initialPointX, initialPointY;

	// The player can move the ghost platform around to determine
	// where to spawn the real platform
	void moveGhost () {
		float vert = Input.GetAxisRaw ("Vertical");
		float horizontal = Input.GetAxisRaw ("Horizontal");

		Vector3 temp = ghost.transform.position;
		temp.y += vert * platMoveSpeed;	                    
		temp.x += horizontal * platMoveSpeed;

		if (pM.facingRight) {
			temp.x = Mathf.Clamp (temp.x, (transform.position.x - spawnDist), (initialPointX + spawnDist));
			if (temp.x <= transform.position.x)
			{
				pM.Flip();
				initialPointX = transform.position.x - spawnDist;
			}
		} else {
			temp.x = Mathf.Clamp (temp.x, (initialPointX - spawnDist), (transform.position.x + spawnDist));
			if (temp.x >= transform.position.x)
			{
				pM.Flip();
				initialPointX = transform.position.x + spawnDist;
			}
		}

		temp.y = Mathf.Clamp (temp.y, (initialPointY - bound), (initialPointY + bound));
		ghost.transform.position = temp;
	}

	public void setRealPlatform (GameObject plat) {
		//previous = real;
		real = plat;
		//GameObject.DestroyImmediate (plat);
	}
}
