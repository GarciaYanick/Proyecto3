using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    private PlayerInputs _pinput;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Vector2 _movementInput;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void OnEnable()
    {
        if (_pinput == null)
        {
            _pinput = new PlayerInputs();
            _pinput.Player.Move.performed += i => _movementInput = i.ReadValue<Vector2>();
        }
        _pinput.Enable();
    }
    private void OnDisable()
    {
        _pinput.Disable();
    }
    private void FixedUpdate()
    {
        _rb.velocity = _movementInput*_speed;

    }
    private void Update()
    {
        HandleMove();
    }
    private void HandleMove()
    {
        if (_movementInput.x != 0 || _movementInput.y !=0)
        {
            _animator.SetFloat("Horizontal", _movementInput.x);
            _animator.SetFloat("Vertical", _movementInput.y);
            _animator.SetBool("isMoving", true);        
        }
        else _animator.SetBool("isMoving", false);

    }
}
