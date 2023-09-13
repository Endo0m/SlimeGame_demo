
using UnityEngine;
namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5.0f;  // Скорость перемещения
        public float jumpForce = 10.0f; // Сила прыжка

        private Rigidbody rb;
        private bool isGrounded;
        private Transform cameraTransform; // Ссылка на трансформацию камеры

        private Animator anim;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            // Получаем трансформацию камеры
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
        }

        private void Update()
        {
            // Проверка, находится ли персонаж на земле
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

            // Перемещение
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (cameraTransform != null)
            {
                // Преобразуем направление движения относительно направления камеры
                Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
                Vector3 moveDirection = cameraForward * verticalInput + cameraTransform.right * horizontalInput;

                // Прыжок
                if (isGrounded && Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    anim.SetTrigger("Jump");
                }

                // Определение направления взгляда
                if (moveDirection != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                }

                // Применение силы для перемещения
                rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
                anim.SetFloat("Speed", moveDirection.magnitude);
            }
        }
    }
}