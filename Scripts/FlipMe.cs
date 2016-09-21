using UnityEngine;
using System.Collections;

public class FlipMe : MonoBehaviour {

    Rigidbody2D myrigidbody2D;
    PlayerController player;

    bool facingRight = false;

    // Use this for initialization
    void Start () {
        myrigidbody2D = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();
    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<Rigidbody2D>().position.x > transform.position.x) {
            if (facingRight == true)
                Flip();
        }
        else {
            if (facingRight == false)
                Flip();
        }
    }

    void Flip() {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
