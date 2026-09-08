using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed = 10.0f;
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] bool isGrounded = false;
    Rigidbody2D rb;
    Vector2 inputDir;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        print("STARTED PLAYER MOVEMENT!");
    }

    // Update is called once per frame
    void Update()
    {
        isGrounded = rb.IsTouchingLayers(LayerMask.GetMask("Default"));
        rb.linearVelocityX = inputDir.x * movementSpeed;
    }

    public void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        print("InputDir: " + inputDir);
    }
    public void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
