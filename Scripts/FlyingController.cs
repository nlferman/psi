using UnityEngine;
using System.Collections;

public class FlyingController : MonoBehaviour {

	public GameObject movingObject;
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
		movingObject.transform.position = Vector3.MoveTowards(movingObject.transform.position,
			currentPoint.position, Time.deltaTime * moveSpeed);

		if(movingObject.transform.position == currentPoint.position) {
			pointSelection++;

			if (pointSelection == points.Length)
				pointSelection = 0;

			currentPoint = points[pointSelection];

		}

	}


}
