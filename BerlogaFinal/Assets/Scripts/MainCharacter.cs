using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField]
    private float _jumpForce;
    [SerializeField]
    private float _smoothness;
    [SerializeField]
    private Camera _camera;
    [SerializeField]
    private RobotHelper _robot;
    [SerializeField]
    private PlayerController _playerController;

    private float _currentSpeed;
    private Animator _animator;
    private Rigidbody2D rb;
    private bool isGrounded;
    private Transform _playerTransform;
    private TemperatureManager _temperatureManager;
    private ForceMode2D _forceMode = ForceMode2D.Impulse;
    private int _jumpsLeft = 2;
    private Collider2D _collider;

    private float friction;

    [SerializeField] private AudioSource snowJumpAudio;

    void Start()
    {
        _collider = GetComponent<Collider2D>();
        _temperatureManager = FindAnyObjectByType<TemperatureManager>();
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        _playerTransform = GetComponent<Transform>();
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
            _playerController.Enable();
        }
    }

    public void Enable()
    {
        enabled = true;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Disable()
    {
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
        CameraMove();
        Flip();
        Jump();
        ChangeCharacter();
    }

    void Jump()
    {
        var hit = Physics2D.BoxCast(_playerTransform.position, new Vector3(0.6f, 3, 0), 0, Vector2.down, 0.3f, LayerMask.GetMask("Ground"));
        if (Input.GetKeyDown(KeyCode.Space) && ((isGrounded && hit.collider != null) || _jumpsLeft > 0))
        {
            _jumpsLeft--;
            rb.velocity = Vector2.up * _jumpForce;
            snowJumpAudio.Play();
        }
    }

    private void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 movement = new Vector2(horizontalInput, 0);
        rb.AddForce(new Vector2(movement.x * _currentSpeed, 0), _forceMode);
        rb.velocity = new Vector2(rb.velocity.x * friction, rb.velocity.y);
    }

    public void SuperJump()
    {
        rb.velocity = new Vector2(rb.velocity.x, _jumpForce * 1.3f);
    }

    private void CameraMove()
    {
        Vector3 targetPosition = new Vector3(_playerTransform.position.x, _playerTransform.position.y, _camera.transform.position.z);
        _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition, Time.deltaTime * _smoothness);
    }

    private void Flip()
    {
        Vector3 currentScale = _playerTransform.localScale;
        if (rb.velocity.x < 0.1f)
        {
            currentScale.x = -Mathf.Abs(currentScale.x);
        }
        else if (rb.velocity.x > 0.1f)
        {
            currentScale.x = Mathf.Abs(currentScale.x);
        }
        _playerTransform.localScale = currentScale;
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            _jumpsLeft = 2;
            _forceMode = ForceMode2D.Impulse;
            isGrounded = true;
            friction = 0.8f;
            _currentSpeed = speed;
        }
        else if (collision.transform.CompareTag("Ice"))
        {
            _jumpsLeft = 2;
            _forceMode = ForceMode2D.Force;
            isGrounded = true;
            friction = 0.995f;
            _currentSpeed = speed * 1;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = -3;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HeatArea"))
        {
            _temperatureManager.temperatureDecayRate = 1;
        }
    }
}
