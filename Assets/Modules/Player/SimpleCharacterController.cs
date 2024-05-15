using UnityEngine;

namespace Sahab.Player
{
    public class SimpleCharacterController : MonoBehaviour
    {
        public float speed = 5.0f;
        public float turnSpeed = 180.0f;

        private CharacterController controller;

        void Start()
        {
            controller = GetComponent<CharacterController>(); // Get the CharacterController component
        }

        void Update()
        {

            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");


            Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);

            if (direction.magnitude > 0)
            {
                // Apply rotation based on input direction
                transform.Rotate(Vector3.up, horizontalInput * turnSpeed * Time.deltaTime);

                // Move the character in the forward direction based on speed and time
                controller.Move(transform.forward * speed * Time.deltaTime);
            }
        }
    }
}

