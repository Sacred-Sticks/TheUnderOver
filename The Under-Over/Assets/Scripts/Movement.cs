using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	[Header("Input Actions")]
	[SerializeField] private InputActionAsset playerControls;
	[SerializeField] private float moveSpeed;
	[SerializeField] private float jumpForce;
	
	[Space]
	[Header("Jump Inputs")]
	[SerializeField] private Transform feet;
	[SerializeField] private LayerMask ground;
	[SerializeField] private float floorRange;

	private InputAction moveAction;
	private InputAction jumpAction;
	private Rigidbody rb;
	private Vector2 movementInput;
	private float jumpInput;
	
	private void Awake() {
		var actionMap = playerControls.FindActionMap("Main Controls");
		moveAction = actionMap.FindAction("Movement");
		
		moveAction.performed += OnMoveUpdate;
		moveAction.canceled += OnMoveUpdate;
		moveAction.Enable();

		jumpAction = actionMap.FindAction("Jump");
		jumpAction.performed += OnJumpUpdate;
		jumpAction.canceled += OnJumpUpdate;
		jumpAction.Enable();

		rb = GetComponent<Rigidbody>();
	}

	private void OnMoveUpdate(InputAction.CallbackContext context) {
		movementInput = context.ReadValue<Vector2>();

		movementInput = movementInput.normalized;
	}

	private void OnJumpUpdate(InputAction.CallbackContext context) {
		jumpInput = context.ReadValue<float>();
	}

	private void Update() {
		Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.y);
		transform.position += movement * Time.deltaTime * moveSpeed;

		if (CheckJump()) {
			rb.AddForce(Vector3.up * jumpInput * jumpForce);
		}
	}

	private bool CheckJump() {
		return Physics.CheckSphere(feet.position, floorRange, ground);
	}
}
