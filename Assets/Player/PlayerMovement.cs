using Unity.VisualScripting.FullSerializer;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] float movementSpeed = 100.0f;
    [SerializeField] float jumpForce = 10.0f;
    [SerializeField] bool isGrounded = false;
    [SerializeField] Transform flip;
    [SerializeField] Transform groundCheck;
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
        GroundCheck();
        rb.linearVelocityX = inputDir.x * movementSpeed;
        
        /*Vector2 vel = inputDir;
        vel.y = 0.0f;
        rb.AddForce(inputDir * movementSpeed * Time.deltaTime);*/
        //rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -10.0f, 10.0f);
    }

    public void OnMove(InputValue value)
    {
        inputDir = value.Get<Vector2>();
        
        if (inputDir.x != 0)
        {   
            // Mathf.Abs / Mathf.Sign / Mathf.Clamp / Mathf.Max / Mathf.Min

            Vector3 newScale = flip.localScale;
            newScale.x = inputDir.x;

            flip.localScale = newScale;
        }
        
        
        print("InputDir: " + inputDir);
    }
    public void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
        
    }
    private void GroundCheck()
    {   
        //Regular Layer Check here
        bool touchingDefault = rb.IsTouchingLayers(LayerMask.GetMask("Default"));
        
        //Raycast Check Here
        RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, 0.1f, LayerMask.GetMask("Default"));
        bool hitGround = hit.collider != null;
        Debug.DrawRay(groundCheck.position, Vector2.down * 0.1f, Color.red);

        //Is touching layer and ray hits the floor down
        isGrounded = touchingDefault && hitGround;
    }
}
