using UnityEngine;

public class ControlCameraByMouse : MonoBehaviour
{
    public Transform cameraTransform; // Камера (дочірній об’єкт голови)
    public Transform headTransform;
    public float rotationSpeed = 150f;

    private float verticalAngle = 0f;
    private float horizontalAngle = 0f;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

        horizontalAngle += mouseX;

        verticalAngle -= mouseY;
        verticalAngle = Mathf.Clamp(verticalAngle, -60f, 60f);

        headTransform.localRotation = Quaternion.Euler(verticalAngle, horizontalAngle, 0f);
        cameraTransform.localRotation = Quaternion.identity;
    }
}
