using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Controls input;
    private Vector2 moveVector = Vector2.zero;
	private bool left;
	private bool right;
	private bool up;
	private bool down;
	
    [SerializeField] Rigidbody2D rb2D;
    [SerializeField] float speed;

    [SerializeField] [Range(-10, 10)]public float orientation = 0f;
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
		
		left = moveVector.x >= 0.1f;
		right = moveVector.x <= -0.1f;
		up = moveVector.y <= -0.1f;
		down = moveVector.y <= -0.1f;

        if (left)
        {
            orientation = orientation - 10f;
            if (orientation <= -10)
            {
                orientation = -10;
            }
        }

        if (right)
        {
            orientation = orientation + 10f;
            if (orientation >= 10)
            {
                orientation = 10;
            }
        }

        if (up)
        {
            yScrollSpeed = 13;
        }

        if (down)
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
