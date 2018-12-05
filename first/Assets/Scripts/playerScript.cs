using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript : MonoBehaviour {

	public float moveSpeed;
	private Rigidbody rb;
	public float jumpForce = 7;


	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		//Movement
		Vector3 dirVector = new Vector3 (moveHorizontal, 0, moveVertical).normalized;
 		rb.MovePosition (transform.position + dirVector * Time.deltaTime * moveSpeed);

		// Jumping
		bool isGrounded = rb.transform.position.y <= 0.5;
		
		if(isGrounded && Input.GetKeyDown(KeyCode.Space)){
			rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
		}
	}
}
