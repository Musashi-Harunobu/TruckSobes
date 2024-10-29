using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f; 
    [SerializeField] private float rotationSpeed = 720f; 
    [SerializeField] private float gravity = -9.81f; 
    
    private CharacterController characterController;
    private Vector3 velocity;             
    private Transform cameraTransform;   

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        cameraTransform = Camera.main.transform;
    }

    void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        
        Vector3 direction = (cameraTransform.forward * vertical + cameraTransform.right * horizontal).normalized;
        direction.y = 0; 

        
        if (direction.magnitude >= 0.1f)
        {
            
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            
            characterController.Move(direction * moveSpeed * Time.deltaTime);
        }

        
        if (characterController.isGrounded)
        {
            if (velocity.y < 0)
            {
                velocity.y = -2f; 
            }
        }
        else
        {
            
            velocity.y += gravity * Time.deltaTime;
        }

        
        characterController.Move(velocity * Time.deltaTime);
    }
}
