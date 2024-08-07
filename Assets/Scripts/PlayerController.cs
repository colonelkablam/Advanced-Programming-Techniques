using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Input Actions
    private PlayerControls playerControls;

    // Cached input values
    private Vector2 moveInput;
    private float lookInput;  // Only horizontal (X-axis) input for rotation
    private bool isJumping;
    private Vector3 moveDirection;
    // Movement and rotation parameters
    public float moveSpeed;
    public float jumpForce;
    public float rotationSpeed;  // Speed of rotation

    // Components
    private Rigidbody rb;
    private Animator animator;

    // Jumping state
    public bool isGrounded;

    //States to help deal with different actions
    //Advanced Task:
    //Do the states definition/declaration need to be in the Player Controller
    //Can the player states use a common game pattern in Unity?
    public enum PlayerState
    {
        Normal,
        Jumping,
        Interaction
    }

    private PlayerState state;

    private void Awake()
    {
        // Initialize input actions
        playerControls = new PlayerControls();

        // Get the Rigidbody and Animator components
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        // Bind actions to methods
        playerControls.Locomotion.Move.performed += ctx => moveInput = ctx.ReadValue<Vector2>();
        playerControls.Locomotion.Move.canceled += ctx => moveInput = Vector2.zero;

        playerControls.Locomotion.Look.performed += ctx => lookInput = ctx.ReadValue<Vector2>().x;  // Only X-axis for rotation
        playerControls.Locomotion.Look.canceled += ctx => lookInput = 0f;

        playerControls.Locomotion.Jump.performed += ctx => TryJump();
    }

    private void Start()
    {
        // read all the player values
        moveSpeed = PlayerManager.instance.playerSO.speed;
        jumpForce = PlayerManager.instance.playerSO.jumpForce;
        rotationSpeed = PlayerManager.instance.playerSO.rotationSpeed;
    }

    private void OnEnable()
    {
        // Enable the input actions
        playerControls.Locomotion.Enable();
    }

    private void OnDisable()
    {
        // Disable the input actions
        playerControls.Locomotion.Disable();
    }

    private void Update()
    {
        if (state == PlayerState.Normal)
        {
            // Handle player rotation based on horizontal mouse input (left/right rotation)
            float rotationAmount = lookInput * rotationSpeed * Time.deltaTime;
            transform.Rotate(0f, rotationAmount, 0f);

            // Handle movement in the direction the player is facing
            moveDirection = transform.forward * moveInput.y + transform.right * moveInput.x;
            moveDirection.Normalize();  // Normalize to maintain consistent movement speed
            rb.velocity = moveDirection * moveSpeed + new Vector3(0, rb.velocity.y, 0);


            // Update animator parameters for the blend tree
            animator.SetFloat("Horizontal", moveInput.x);
            animator.SetFloat("Vertical", moveInput.y);
        }

        if (state == PlayerState.Interaction)
        {
            state = PlayerState.Normal;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            state = PlayerState.Interaction;
        }
    }

    private void TryJump()
    {
        if (isGrounded)
        {
            isGrounded = false; // Set isGrounded to false until the player lands
            animator.SetBool("isJumping", true);
            state = PlayerState.Jumping;
        }
    }

    public void JumpAction()
    {
        // Calculate forward movement component to retain during jump
        Vector3 forwardMomentum = transform.forward * (moveInput.y * moveSpeed);

        // Apply jump force with retained forward momentum
        rb.velocity = new Vector3(forwardMomentum.x, rb.velocity.y, forwardMomentum.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the player has collided with the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true; // Player is on the ground
            animator.SetBool("isJumping", false);
            state = PlayerState.Normal;

        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Check if the player has left the ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false; // Player is no longer on the ground
        }
    }

    private bool IsGrounded()
    {
        // Implement ground detection logic
        return true; // Placeholder; replace with actual ground check
    }

    //Do the functions below really belong in the Player Controller
    public void ChangeState(int newState)
    {
        state=(PlayerState)newState;
    }

    public bool IsInteracting()
    {
        if (state == PlayerState.Interaction) return true;
        return false;
    }

    public void  ResetToDefault()
    {
        state=PlayerState.Normal;
    }
}
