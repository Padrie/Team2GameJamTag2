using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    [Header("Objects")]
    public CharacterController characterController;
    public Transform body;
    
    [Header("Logic")]
    public Vector3 velocity;
    public float gravity = -9.81f;
    public bool isGrounded;
    public bool isCrouching;
    public float groundDistance = 0.4f;

    [Header("Movement")]
    public float crawlSpeed = 1f;
    public float crouchSpeed = 2.5f;
    public float walkSpeed = 4f;
    public float runSpeed = 6f;
    float inputX , inputZ;

    [Header("Camera")]
    public Camera camera;
    public float sensitivity = 400;
    float rotX , rotY;
    
    [Header("Animation")]
    public Animator animator;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    { 
        CheckGrounded();
        
        HandleInput();
        
        HandleCameraMovement();
        
        if (Input.GetKeyDown(KeyCode.C))
        {
            HandleCrawling();
        }
    }

    void FixedUpdate()
    {
        HandleGravity();
        
        HandleWalking(walkSpeed);

        
    }

    public void HandleInput()
    {
        inputX = Input.GetAxis("Horizontal");
        inputZ = Input.GetAxis("Vertical");
    }

    public void HandleGravity()
    {
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f;
        }
        
        velocity.y += gravity * Time.deltaTime;
        
        characterController.Move(velocity * Time.deltaTime);
    }

    public void HandleWalking(float speed)
    {
        Vector3 move = transform.right * inputX + transform.forward * inputZ;
        
        characterController.Move(move * speed * Time.deltaTime);
        
    }

    public void HandleCrawling()
    {
        
        if (isCrouching)
        {
            animator.SetBool("Crawl" , isCrouching);
            isCrouching = false;
        }
        else
        {
            animator.SetBool("Crawl" , isCrouching);
            isCrouching = true;
        }
    }

    public void CheckGrounded()
    {
        isGrounded = Physics.Raycast(transform.position, Vector3.down, groundDistance); 
    }

    public void HandleCameraMovement()
    {
        //Mouse Input
        rotX += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        rotY -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;
        
        //Limit rot
        rotY = Mathf.Clamp(rotY, -90, 90);
        
        //Rotate Camera and Player(Body)
        camera.transform.localRotation = Quaternion.Euler(rotY, 0 , 0);
        
        //body.Rotate(Vector3.up * rotX);
        transform.rotation = Quaternion.Euler(0, rotX, 0);
    }
    
}
