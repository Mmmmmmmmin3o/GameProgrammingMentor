using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    private float currentSpeed;

    private CharacterController controller;
    public Transform cameraTransform;

    [Header("Stamina Settings")]
    public float maxStamina = 100f;
    public float stamina;
    public float staminaDecreaseRate = 20f;
    public float staminaRecoveryRate = 10f;

    [Header("UI Settings")]
    public RectTransform staminaBar;
    private float staminaBarMaxWidth;

    // 달리기 잠금 여부
    private bool staminaLocked = false;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        currentSpeed = walkSpeed;
        stamina = maxStamina;

        staminaBarMaxWidth = staminaBar.sizeDelta.x;
    }

    void Update()
    {
        // 달리기 가능 조건: Shift 누름 + 스태미나 > 0 + 잠금 해제 상태
        bool canRun = Input.GetKey(KeyCode.LeftShift) && stamina > 0f && !staminaLocked;

        if (canRun)
        {
            currentSpeed = runSpeed;
            stamina -= staminaDecreaseRate * Time.deltaTime;
            if (stamina <= 0f)
            {
                stamina = 0f;
                staminaLocked = true; // 스태미나가 바닥나면 잠금
            }
        }
        else
        {
            currentSpeed = walkSpeed;
            stamina += staminaRecoveryRate * Time.deltaTime;
            if (stamina > maxStamina) stamina = maxStamina;

            // 스태미나가 30% 이상 회복되면 잠금 해제
            if (stamina >= maxStamina * 0.3f)
            {
                staminaLocked = false;
            }
        }

        // 이동 처리
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

        // UI 바 크기 갱신
        if (staminaBar != null)
        {
            float newWidth = (stamina / maxStamina) * staminaBarMaxWidth;
            staminaBar.sizeDelta = new Vector2(newWidth, staminaBar.sizeDelta.y);
        }
    }
}
