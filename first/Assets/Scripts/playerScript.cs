using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	public float moveSpeed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 dirVector = new Vector3 (Input.GetAxis ("Horizontal"), 0, Input.GetAxis ("Vertical")).normalized;
 		GetComponent <Rigidbody> ().MovePosition (transform.position + dirVector * Time.deltaTime * moveSpeed);
	}
}
