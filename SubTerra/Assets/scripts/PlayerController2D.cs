using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	Rigidbody2D rb;
	Vector2 velocity;

	public float speed;
	public float jumpForce;

	bool jump = false;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D> ();
		rb.velocity = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			jump = true;
		}
	}

	void FixedUpdate() {
		if (jump) {
			rb.AddForce (new Vector2 (0, jumpForce));
			jump = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		this.gameObject.SetActive (false);
	}
}
