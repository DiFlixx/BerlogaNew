using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float ladderSpeed;

    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private CameraMovement _camera;
    [SerializeField]
    private RobotHelper _robot;
    [SerializeField]
    private PlayerController _playerController;
    [SerializeField]
    private GameObject _box;

    private Vector2 _prePosition;
    private float _currentSpeed;
    private Animator _animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private TemperatureManager _temperatureManager;
    private ForceMode2D _forceMode = ForceMode2D.Impulse;
    private int _jumpsLeft = 2;
    private Collider2D _collider;
    private bool _isOnLadder = false;
    private bool _isNearLadder = false;
    private BoxCollider2D _boxCollider;
    public bool _isMain;

    private float friction;

    [SerializeField] private AudioSource snowJumpAudio;

    void Start()
    {
        _camera.SetTarget(transform);
        _currentSpeed = speed;
        _isMain = true;
        _collider = GetComponent<Collider2D>();
        _temperatureManager = FindAnyObjectByType<TemperatureManager>();
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _robot.ChangePlayer(_box);
    }

    private void OnEnable()
    {
        
        Start();
    }

    private void OnDisable()
    {
        rb.velocity = new Vector3(0,0);
    }

    private void ChangeCharacter()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Disable();
            _isMain = false;
            _playerController._isMain = true;
            _playerController.Enable();
        }
    }

    public void Enable()
    {
        if (!_isMain) return;
        enabled = true;
        _camera.SetTarget(transform);
        _robot.ChangePlayer(_box);
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Disable()
    {
        if (!_isMain) return;
        _animator.SetFloat("HorizontalMove", 0f);
        _animator.SetFloat("VerticalMove", 0f);
        enabled = false;
        rb.velocity = new Vector3(0,0);
        rb.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
        rb.angularVelocity = 0;
    }

    void Update()
    {
        float HorizontalMove = Input.GetAxis("Horizontal") * _currentSpeed;
        float verticalInput = Input.GetAxis("Vertical");
        float VerticalMove = rb.velocity.y;
        _animator.SetFloat("HorizontalMove", Mathf.Abs(HorizontalMove));
        _animator.SetFloat("VerticalMove", VerticalMove);
        Move();
        Flip();
        Jump();
        ChangeCharacter();
    }

    void Jump()
    {
        var hit = Physics2D.BoxCast(transform.position, new Vector3(0.01f, 3, 0), 0, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
        if (Input.GetKeyDown(KeyCode.Space) && ((isGrounded && hit.collider != null) || _jumpsLeft > 0))
        {
            StopClimb();
            _jumpsLeft--;
            rb.velocity = Vector2.up * _jumpForce;
            snowJumpAudio.Play();
        }
    }

    private void Climb()
    {
        rb.velocity = Vector2.zero;
        _isOnLadder = true;
        rb.gravityScale = 0;
        _currentSpeed = ladderSpeed;
    }

    private void StopClimb()
    {
        _isOnLadder = false;
        rb.gravityScale = 5;
        _currentSpeed = speed;
        _isNearLadder = false;
    }

    private void Move()
    {
        _prePosition = rb.position;
        if (_isNearLadder && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) && !_isOnLadder)
        {
            Climb();
        }
        if (_isOnLadder)
        {
            if (transform.position.y > _boxCollider.bounds.max.y)
            {
                transform.position = new Vector2(transform.position.x, _boxCollider.bounds.max.y);
            }
            if (_collider.bounds.max.x < _boxCollider.bounds.min.x || _collider.bounds.min.x > _boxCollider.bounds.max.x)
            {
                StopClimb();
            }
            _jumpsLeft = 1;
            float verticalInput = Input.GetAxis("Vertical");
            //rb.position = new Vector2(rb.position.x, rb.position.y + verticalInput * Time.deltaTime * _currentSpeed);
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movement = new Vector2(horizontalInput, verticalInput);
            rb.AddForce(movement * _currentSpeed, _forceMode);
            rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y * friction);
        }
        else
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            Vector2 movementX = new Vector2(horizontalInput, 0);
            rb.AddForce(new Vector2(movementX.x * _currentSpeed, 0), _forceMode);
            rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y);
        }
        if (_boxCollider!=null && _boxCollider.bounds.Contains(transform.position))
        {
            _isNearLadder = true;
        }
    }

    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, _jumpForce * 1.3f);
    }

    private void Flip()
    {
        Vector3 currentScale = transform.localScale;
        if (rb.velocity.x < -0.1f)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }
        else if (rb.velocity.x > 0.1f)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        transform.localScale = currentScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            var hit = Physics2D.BoxCast(transform.position, new Vector3(0.01f, 3, 0), 0, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
            if (hit) _jumpsLeft = 2;
            _forceMode = ForceMode2D.Impulse;
            isGrounded = true;
            friction = 0.8f;
            //_currentSpeed = speed;
        }
        else if (collision.transform.CompareTag("Ice"))
        {
            var hit = Physics2D.BoxCast(transform.position, new Vector3(0.01f, 3, 0), 0, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
            if (hit) _jumpsLeft = 2;
            _forceMode = ForceMode2D.Force;
            isGrounded = true;
            friction = 0.995f;
            //_currentSpeed = speed;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            isGrounded = false;
        }
        else if (collision.transform.CompareTag("Ice"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = -3;
        }
        if (collision.CompareTag("LadderTrigger"))
        {
            _boxCollider = (BoxCollider2D)collision;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = 1;
        }
        if (collision.CompareTag("LadderTrigger"))
        {
            if (!_isOnLadder) _isNearLadder = false;
        }
    }
}
