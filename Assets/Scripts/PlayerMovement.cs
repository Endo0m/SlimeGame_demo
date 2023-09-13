
using UnityEngine;
namespace WildBall.Inputs
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        public float moveSpeed = 5.0f;  // �������� �����������
        public float jumpForce = 10.0f; // ���� ������

        private Rigidbody rb;
        private bool isGrounded;
        private Transform cameraTransform; // ������ �� ������������� ������

        private Animator anim;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            anim = GetComponent<Animator>();

            // �������� ������������� ������
            Camera mainCamera = Camera.main;
            if (mainCamera != null)
            {
                cameraTransform = mainCamera.transform;
            }
        }

        private void Update()
        {
            // ��������, ��������� �� �������� �� �����
            isGrounded = Physics.Raycast(transform.position, Vector3.down, 0.1f);

            // �����������
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");

            if (cameraTransform != null)
            {
                // ����������� ����������� �������� ������������ ����������� ������
                Vector3 cameraForward = Vector3.Scale(cameraTransform.forward, new Vector3(1, 0, 1)).normalized;
                Vector3 moveDirection = cameraForward * verticalInput + cameraTransform.right * horizontalInput;

                // ������
                if (isGrounded && Input.GetButtonDown("Jump"))
                {
                    rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                    anim.SetTrigger("Jump");
                }

                // ����������� ����������� �������
                if (moveDirection != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(moveDirection);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 10f);
                }

                // ���������� ���� ��� �����������
                rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
                anim.SetFloat("Speed", moveDirection.magnitude);
            }
        }
    }
}