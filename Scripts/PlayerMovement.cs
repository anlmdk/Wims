using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private new Rigidbody2D rigidbody;
    public Animator animator;
    public Joystick joystick;

    public float runSpeed;
    public float jumpPower;

    float horizontalMove = 0f;

    public float checkRadius;
    public LayerMask whatIsGround;
    public Transform feetPos;
    private bool isGrounded;
    private bool jumpChecking;

    [Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .05f;  // How much to smooth out the movement
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private Vector3 m_Velocity = Vector3.zero;

    private const string SPEED = "Speed";
    private const string JUMPING = "isJumping";

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    // Update is called once per frame
    public void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if (joystick.Horizontal >= .7f)
        {
            horizontalMove = runSpeed;
        }
        else if (joystick.Horizontal <= -.7f)
        {
            horizontalMove = -runSpeed;
        }
        else
        {
            horizontalMove = 0f;
        }
        animator.SetFloat(SPEED, Mathf.Abs(horizontalMove));
        if (isGrounded)
        {
            animator.SetBool(JUMPING, false);
        }
    }
    public void FixedUpdate()
    {
        Move(horizontalMove * Time.fixedDeltaTime);
    }
    public void Jump()
    {
        // If velocity zero on y axis character will jump
        if (!isGrounded && !jumpChecking)
        {
            rigidbody.velocity = Vector2.up * jumpPower;
            jumpChecking = true;
            animator.SetBool(JUMPING, true);
        }
    }
    private void Move(float move)
    {
        // Move the character by finding the target velocity
        Vector3 targetVelocity = new Vector2(move * 10f, rigidbody.velocity.y);
        // And then smoothing it out and applying it to the character
        rigidbody.velocity = Vector3.SmoothDamp(rigidbody.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

        // If the input is moving the player right and the player is facing left...
        if (move > 0 && !m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (move < 0 && m_FacingRight)
        {
            // ... flip the player.
            Flip();
        }
    }
    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        transform.Rotate(0, 180, 0);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpChecking = false;
            animator.SetBool(JUMPING, false);
        }
    }
}
