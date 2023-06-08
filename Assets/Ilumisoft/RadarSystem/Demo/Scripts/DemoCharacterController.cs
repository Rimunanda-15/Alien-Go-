using UnityEngine;

namespace Ilumisoft.RadarSystem.Demo
{
    [RequireComponent(typeof(CharacterController))]
    public class DemoCharacterController : MonoBehaviour
    {
        public float rotationSpeed = 10.0f;
        public float moveSpeed = 5;

        CharacterController CharacterController { get; set; }

        void Awake()
        {
            CharacterController = GetComponent<CharacterController>();
        }

        void Update()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            Vector3 movement = moveSpeed * Time.deltaTime * vertical * transform.forward;
            Vector3 rotation = horizontal * rotationSpeed * Time.deltaTime * Vector3.up;

            CharacterController.Move(movement);
            transform.Rotate(rotation);
        }
    }
}