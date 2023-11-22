using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float movementSpeed;
    private Rigidbody2D rb = null;
    private PlayerInput input;
    private Vector2 moveVector = Vector2.zero;
    private void Awake()
    {
        input = new PlayerInput();
        rb = GetComponent<Rigidbody2D>();
        input.Player.Movement.performed += OnMovementPerformed;
        input.Player.Movement.canceled += OnMovementCancelled;
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovementPerformed;
        input.Player.Movement.canceled -= OnMovementCancelled;
    }

    
    // When player presses any of the keya
    private void OnMovementPerformed(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    
    // When player stops pressing any of the keys
    private void OnMovementCancelled(InputAction.CallbackContext value)
    {
        moveVector = value.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = moveVector * movementSpeed;
    }
}
