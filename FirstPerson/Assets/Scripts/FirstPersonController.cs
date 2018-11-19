using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    public float movementSpd = 10.0f;
    public float mouseSens = 2.0f;

    public float rotYRange = 60.0f;
    float verticalRotation = 0;

    float verticalVelocity = 0;
    public float jumpSpd = 20.0f;

    CharacterController characterController;

    // Use this for initialization
    void Start()
    {
        Cursor.visible = false;
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {


        //Mouse rotation

        // Left/Right
        float rotX = Input.GetAxis("Mouse X") * mouseSens;
        transform.Rotate(0, rotX, 0);

        // Up/Down
        verticalRotation -= Input.GetAxis("Mouse Y") * mouseSens;
        verticalRotation = Mathf.Clamp(verticalRotation, -rotYRange, rotYRange);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0, 0);



        /*
			ÞARF AÐ FINNA ÚT ÚR JUMPING!
		 */



        //Movement

        float verticalSpd = Input.GetAxis("Vertical") * movementSpd;
        float horizontalSpd = Input.GetAxis("Horizontal") * movementSpd;

        verticalVelocity = (Physics.gravity.y * Time.deltaTime);

        if (characterController.isGrounded && Input.GetButton("Jump"))
        {
            verticalVelocity = jumpSpd;
        }

        Vector3 moveSpd = new Vector3(horizontalSpd, verticalVelocity, verticalSpd);

        moveSpd = transform.rotation * moveSpd;

        characterController.Move(moveSpd * Time.deltaTime);
        print(verticalVelocity);
    }
}
