using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;

    private bool canJump;

    //For checking if the player can jump
    public Transform feetPosition;
    private bool grounded;
    private float groundCheckSize =0.5f;
    public LayerMask groundLayer;

    [SerializeField] private float gravityFallingForce;
    [SerializeField] GameObject PauseCanvas;
    private Vector3 gravityVector;

    public bool canMove = true;

    private float jumpCooldown = 0.2f;
    private float untilNextJump;
    private bool isRunning;
    private bool isJumping;

    public int bonusJumps;
    private int jumpsLeft;

    private float groundCheckCooldown = 0.5f;
    private float untilGroundCheck;

    public Animator characterAnimator;

    private float idleTimeMin = 20f;
    private float idleTimeMax = 50f;
    private float idleCooldown;

    private Digging diggingHandler;

    void Start()
    {
        jumpsLeft = bonusJumps;
        untilNextJump = 0;
        untilGroundCheck = 0;
        _rb = GetComponent<Rigidbody>();
        gravityVector = new Vector3(0, -Physics.gravity.y, 0);
        idleCooldown = Random.Range(idleTimeMin, idleTimeMax);

        diggingHandler = GetComponent<Digging>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            canMove = PauseCanvas.activeSelf;
            PauseCanvas.SetActive(!PauseCanvas.activeSelf);
        }

        if (!canMove) return;

        if (Input.GetAxis("Horizontal") != 0) {
            MovePlayer();
            idleCooldown = Random.Range(idleTimeMin, idleTimeMax);
        }
        else
        {
            isRunning = false;
            characterAnimator.SetBool("isRunning", isRunning);
            
        }

        if (
            (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
             && canJump
           )
        {
            if (isJumping)
            {
                jumpsLeft--;
            }
            Jump();
        }

        if (Input.GetKeyDown(KeyCode.E) && diggingHandler.hasShovel)
        {
            characterAnimator.SetTrigger("Digging");
            diggingHandler.Dig();
        }

        if (_rb.velocity.y < 0.5f)
        {
            _rb.velocity -= gravityVector * gravityFallingForce * Time.deltaTime;
        }

        
        if (idleCooldown <= 0)
        {
            characterAnimator.SetTrigger("LongIdle");
            idleCooldown = Random.Range(idleTimeMin, idleTimeMax);
        }
        CanJump();
        OperateCooldowns();


    }

    private void OperateCooldowns()
    {
        if (!isRunning && !isJumping && idleCooldown > 0)
        {
            idleCooldown -= Time.deltaTime;
        }
        if (untilNextJump >= 0)
        {
            untilNextJump -= Time.deltaTime;
        }
        if (untilGroundCheck > 0)
        {
            untilGroundCheck -= Time.deltaTime;
        }
        else if (untilGroundCheck <= 0)
        {
            isGrounded();
            if (grounded)
            {
                jumpsLeft = bonusJumps;
                isJumping = false;
                characterAnimator.SetBool("isJumping", isJumping);
            }
            else
            {
                if (!isJumping)
                {
                    jumpsLeft = 0;
                }
            }
        }

    }


    private void Jump()
    {
        characterAnimator.SetBool("isJumping", true);
        isJumping = true;
        untilNextJump = jumpCooldown;
        grounded = false;
        untilGroundCheck = groundCheckCooldown;
        _rb.velocity = new Vector3(_rb.velocity.x, _jumpForce, _rb.velocity.z);
        idleCooldown = Random.Range(idleTimeMin, idleTimeMax);
    }

    private void MovePlayer()
    {
        isRunning = true;
        characterAnimator.SetBool("isRunning", isRunning);
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
        canJump = (grounded || (jumpsLeft > 0)) && (untilNextJump <= 0);
    }

    public void isGrounded()
    {
        grounded = Physics.Raycast(feetPosition.position, Vector3.down, groundCheckSize, groundLayer);
    }


}






