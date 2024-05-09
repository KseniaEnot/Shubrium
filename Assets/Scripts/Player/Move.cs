using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Rigidbody _rb;

    private bool _grounded;

    private bool canMove = true;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (!canMove) return;

        if(Input.GetAxis("Horizontal") != 0) MovePlayer();
        if ((Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && _grounded) Jump();
    }

    private void Jump()
    {
        ChangeGround(false);
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

    public void ChangeGround(bool jump) => _grounded = jump;
}
