using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    public float sensitivity = 2f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // 마우스 커서 고정
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;

        // 좌우 회전 (캐릭터 본체)
        playerBody.Rotate(Vector3.up * mouseX);

        // 위아래 회전 (카메라)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -80f, 80f); // 위아래 제한
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
