using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls input;
    private Vector2 moveVector = Vector2.zero;
    private Vector2 horizontal = Vector2.zero;
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float speed;

    [SerializeField] [Range(-10, 10)] float orientation = 0f;
    [SerializeField] [Range(8, 13)] public float yScrollSpeed = 10f;

    private void Awake()
    {
        input = new Controls();
    }

    private void OnEnable()
    {
        input.Enable();
        input.Player.Move.performed += OnMovePerformed;
        input.Player.Move.canceled += OnMoveCanceled;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Move.performed -= OnMovePerformed;
        input.Player.Move.canceled -= OnMoveCanceled;
    }

    private void FixedUpdate()
    {
        rb2D.velocity = moveVector * speed;
        rb2D.rotation = orientation;
    }


    private void OnMovePerformed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();

        if (moveVector.x == 1f)
        {
            orientation = orientation - 10f;
            if (orientation <= -10)
            {
                orientation = -10;
            }
        }

        else if (moveVector.x == -1f)
        {
            orientation = orientation + 10f;
            if (orientation >= 10)
            {
                orientation = 10;
            }
        }

        if (moveVector.y == 1f)
        {
            yScrollSpeed = 13;
        }

        else if (moveVector.y == -1f)
        {
            yScrollSpeed = 8;
        }
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
        orientation = 0;
        yScrollSpeed = 10;
    }
}
