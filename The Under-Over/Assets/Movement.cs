using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
	[SerializeField] private InputActionAsset playerControls;
	[SerializeField] private float moveSpeed;
	
	private InputAction moveInput;
	private Vector2 movementInput;
	
	private void Awake() {
		var actionMap = playerControls.FindActionMap("Main Controls");
		moveInput = actionMap.FindAction("Movement");
		
		moveInput.performed += move;
		moveInput.canceled += move;
		moveInput.Enable();
	}

	private void move(InputAction.CallbackContext context) {
		movementInput = context.ReadValue<Vector2>();

		movementInput = movementInput.normalized;
	}

	private void Update() {
		Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.y);
		transform.position += movement * Time.deltaTime * moveSpeed;
	}
}
