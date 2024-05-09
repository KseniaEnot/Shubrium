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
        if(Input.GetAxis("Horizontal") != 0)
        {
            MovePlayer();
        }

        if (Input.GetKeyDown(KeyCode.W) && _grounded)
        {
            Jump();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            _grounded = true;
        }
    }

    private void Jump()
    {
        _grounded = false;
        _rb.velocity = new Vector3(0, _jumpForce, 0);
    }

    private void MovePlayer()
    {
        float direction = Input.GetAxis("Horizontal");

        if (direction > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        else if (direction < 0)
        {
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        }

        float step = _speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x + direction * step, transform.position.y, transform.position.z), step);
    }

    public void CanMove(bool move)
    {
        canMove = move;
    }
}
