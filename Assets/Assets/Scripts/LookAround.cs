using UnityEngine;

public class LookAround : MonoBehaviour {

    public float mouseSensitivity = 300f;

    private float xRotation = 0f;


    private void Start() {
        // Lock cursor to center of screen and hide it
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update() {
        if (PlayerPrefs.GetInt("mouseLock") == 0)
        {
            // Get mouse movement input
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * 2 * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * 2 * Time.deltaTime;

            // Rotate the camera based on mouse movement
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            transform.parent.Rotate(Vector3.up * mouseX);
        }
    }
}
