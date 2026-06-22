using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 2f;   // 걷기 속도
    public float runSpeed = 4f;   // 달리기 속도
    private float currentSpeed;    // 현재 속도

    private CharacterController controller;
    public Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed; // 시작은 걷기 속도로
    }

    void Update()
    {
        // Shift 누르면 달리기
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = walkSpeed;
        }

        float moveX = Input.GetAxisRaw("Horizontal");
        float moveZ = Input.GetAxisRaw("Vertical");

        Vector3 forward = cameraTransform.forward;
        forward.y = 0f;
        forward.Normalize();

        Vector3 right = cameraTransform.right;
        right.y = 0f;
        right.Normalize();

        Vector3 moveDirection = (forward * moveZ + right * moveX).normalized;

        controller.Move(moveDirection * currentSpeed * Time.deltaTime);
    }
}
