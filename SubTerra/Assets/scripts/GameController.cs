using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {


	public GameObject player;

	// Use this for initialization
	void Start () {
		Instantiate (player, new Vector3 (0, 0, 0), new Quaternion ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
