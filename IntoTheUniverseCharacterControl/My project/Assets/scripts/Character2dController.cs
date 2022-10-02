using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character2dController : MonoBehaviour
{
    [Header("Stats")]
    public float MovementSpeed = 1;
    public int MaxHealth = 100;
    public float MaxVelocity = 1000;
    public float MinVelocity = 0.1F;
    public bool ForceMovement = false;

    private Rigidbody2D _rigidBody;
    private Vector2 _movement;
    private SpriteRenderer _spriteRenderer;
    private Vector2 _facingDirection;
    private Animator _animator;

    // Start is called before the first frame update
    private void Start()
    {
    }

    void Awake()
    {
        // get the components
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = gameObject.GetComponent<Animator>();
    }

    private void Move(Vector2 direction)
    {
        if (ForceMovement)
        {
            var movementX = Input.GetAxis("Horizontal");
            transform.position += new Vector3(movementX, 0, 0) * Time.deltaTime * MovementSpeed;

            var movementY = Input.GetAxis("Vertical");
            transform.position += new Vector3(0, movementY, 0) * Time.deltaTime * MovementSpeed;
        }
        else
        {
            _rigidBody.AddForce(direction * MovementSpeed);
        }
    }

    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(_rigidBody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(_rigidBody.velocity.x), 1f);
        }
    }


    // Update is called once per frame
    private void Update()
    {
        if (_rigidBody.velocity.magnitude > MaxVelocity)
        {
            _rigidBody.velocity = Vector3.ClampMagnitude(_rigidBody.velocity, MaxVelocity);
        }

        _animator.SetBool("isWalking", _rigidBody.velocity.magnitude > 0.15);
        _movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        FlipSprite();
    }

    private void FixedUpdate()
    {
        Move(_movement);
    }
}


