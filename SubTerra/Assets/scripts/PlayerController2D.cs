using UnityEngine;
using System.Collections;

public class PlayerController2D : MonoBehaviour {

	Rigidbody2D rigidbody;
	Vector2 velocity;

	// Use this for initialization
	void Start () {
		rigidbody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxisRaw ("Horizontal");
		float moveVertical = Input.GetAxisRaw ("Vertical");

		velocity = new Vector2 (moveHorizontal, moveVertical).normalized *10;
	}

	void FixedUpdate() {
		Vector2 newPosition = rigidbody.position + velocity * Time.fixedDeltaTime;
		rigidbody.MovePosition (newPosition);
	}
}
