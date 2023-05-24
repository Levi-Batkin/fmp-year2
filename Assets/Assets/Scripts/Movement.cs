using System.Collections;
using UnityEngine;

public class Movement : MonoBehaviour {

    public float speed = 0.2f;
    public float gravity = 9.81f;
    private float yVelocity = 0f;

    private CharacterController controller;
    private Vector3 moveDirection;

    public GameObject movementHint;

    IEnumerator MovementHintShow() {
        movementHint.SetActive(true);
        yield return new WaitForSeconds(3);
        movementHint.SetActive(false);
    }
    private void Start() {
        controller = GetComponent<CharacterController>();
        StartCoroutine(MovementHintShow()); 
    }

    private void Update() {
        // Get input for movement
        if (controller.isGrounded) {
            yVelocity = 0f;
        } else {
            yVelocity -= gravity * Time.deltaTime;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        moveDirection = new Vector3(horizontal, yVelocity, vertical);
        moveDirection = transform.TransformDirection(moveDirection);
        moveDirection *= speed / 3;

        // Apply gravity
        yVelocity -= gravity * Time.deltaTime;

        // Move the controller
        if(PlayerPrefs.GetInt("mouseLock") == 0)
        {
            if (Input.GetKey(KeyCode.LeftShift)) {
                moveDirection *= speed / 2.9f;
                controller.Move(moveDirection * Time.deltaTime);
            }
            else if (Input.GetKeyUp(KeyCode.LeftShift)) {
                moveDirection *= speed / 3;
                controller.Move(moveDirection * Time.deltaTime);
            }
            controller.Move(moveDirection * Time.deltaTime);
        }
    }
}