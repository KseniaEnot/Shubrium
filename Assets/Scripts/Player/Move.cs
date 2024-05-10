using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;

    private bool canJump;
    private bool grounded;

    private bool canMove = true;

    private float jumpCooldown = 0.2f;
    private float untilNextJump;

    public int jumpsAmount;
    private int jumpsLeft;

    private float groundCheckCooldown =0.5f;
    private float untilGroundCheck;



    void Start()
    {
        jumpsLeft = jumpsAmount;
        untilNextJump = 0;
        untilGroundCheck = 0;
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMove) return;

        if (Input.GetAxis("Horizontal") != 0) MovePlayer();
        if (
            (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
             && canJump
           )
        {
            Jump();
            jumpsLeft--;
        }

        if (untilNextJump >= 0)
        {
            untilNextJump -= Time.deltaTime;
        }
        if (untilGroundCheck >= 0)
        {
            untilGroundCheck -= Time.deltaTime;
        }
        CanJump();
    }

    private void Jump()
    {
        untilNextJump = jumpCooldown;
        SetGrounded(false);
        _rb.velocity = new Vector3(0, _jumpForce, 0);
    }

    private void MovePlayer()
    {
        float direction = Input.GetAxis("Horizontal");
        Quaternion targetRotation = Quaternion.identity;
        if (direction > 0)
        {
            targetRotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direction < 0)
        {
            targetRotation = Quaternion.Euler(0f, 180f, 0f);
        }
        transform.rotation = targetRotation;

        Vector3 velocity = new Vector3(direction * _speed, _rb.velocity.y, _rb.velocity.z);
        _rb.velocity = velocity;
    }

    public void CanMove(bool move) => canMove = move;

    public void CanJump()
    {
        canJump = (grounded || (jumpsLeft > 0)) && (jumpsLeft > 0) && (untilNextJump <= 0);
    }

    public void SetGrounded(bool isGrounded)
    {
        
        if (!isGrounded)
        {
            grounded = isGrounded;
        }
        if (untilGroundCheck <= 0)
        {
            grounded = isGrounded;
            CanJump();
            if (isGrounded)
            {
                jumpsLeft = jumpsAmount;
            }
            
        }
        untilGroundCheck = groundCheckCooldown;
        
    }
}
