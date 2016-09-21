using UnityEngine;
using System.Collections;

public class EnemyHelicameraController : MonoBehaviour {

    public GameObject Helicamera;
    public float moveSpeed;
    public Transform currentPoint;
    public Transform[] points;
    public int pointSelection;

    //public bool moveHorizontal;
    bool facingRight = false;

    Rigidbody2D myrigidbody2D;
    PlayerController player;
    private LevelManager levelManager;

    // Use this for initialization
    void Start () {
        currentPoint = points[pointSelection];
		levelManager = FindObjectOfType <LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
        Helicamera.transform.position = Vector3.MoveTowards(Helicamera.transform.position,
            currentPoint.position, Time.deltaTime * moveSpeed);

        if(Helicamera.transform.position == currentPoint.position) {
            pointSelection++;

            if (pointSelection == points.Length)
                pointSelection = 0;

            currentPoint = points[pointSelection];
        }
    }

    // Flips the sprite depending on where the player is
    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    // CHANGE TO HURT PLAYER
    void OnTriggerEnter2D(Collider2D other) {
        if (other.name == "Player") {
            //levelManager.RespawnPlayer();
        }
    }
}
