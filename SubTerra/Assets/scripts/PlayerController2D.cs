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
		//rb.AddForce(new Vector2 (speed, 0));
		rb.velocity = new Vector2 (speed, 0);
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			//velocity = new Vector2 (rigidbody.velocity.x, jumpVelocity);
			jump = true;
		}

		///float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		//float moveVertical = Input.GetAxisRaw ("Vertical");

		//velocity = new Vector2 (moveHorizontal, moveVertical).normalized *10;
	}

	void FixedUpdate() {
		//Vector2 newPosition = rigidbody.position + velocity * Time.fixedDeltaTime;
		if (jump) {
			rb.AddForce (new Vector2 (0, jumpForce));
			jump = false;
		}
	}

	void OnTriggerEnter(Collider other) {
		this.gameObject.SetActive (false);
	}
}
