using UnityEngine;

public class FreeCamController : MonoBehaviour
{
    [SerializeField] private float _moveSpeed = 10.0f;
    [SerializeField] private float _rotateSpeed = 5.0f;
    [SerializeField] private float _maxVerticalAngle = 90.0f;

    private void Start()
    {
        // Hide the cursor and lock it to the game window
        Cursor.lockState = CursorLockMode.Locked;
    }
        
    private void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        var rotateHorizontal = Input.GetAxis("Mouse X");
        var rotateVertical = Input.GetAxis("Mouse Y");

        transform.Translate(new Vector3(horizontal, 0, vertical) * (_moveSpeed * Time.deltaTime));

        // Rotate the camera
        var rotation = transform.rotation;
        var xRotation = rotation.eulerAngles.x - (rotateVertical * _rotateSpeed);
        xRotation = Mathf.Clamp(xRotation, -_maxVerticalAngle, _maxVerticalAngle);

        var yRotation = rotation.eulerAngles.y + (rotateHorizontal * _rotateSpeed);
        yRotation %= 360.0f;

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0.0f);
    }
}
