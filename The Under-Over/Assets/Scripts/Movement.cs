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
	public float interactRange;
	[SerializeField] float slowedPenalty;
	[Space]
	[Header("Jump Inputs")]
	[SerializeField] private Transform feet;
	[SerializeField] private LayerMask ground;
	[SerializeField] private float floorRange;

	private InputAction moveAction;
	private InputAction jumpAction;
	private InputAction useAction;
	private Rigidbody rb;
	private Vector2 movementInput;
	private float jumpInput;
	private GameObject blueCam;
	private GameObject redCam;
	private float currentSpeedVal;
	private void Awake() {

		currentSpeedVal = moveSpeed;
		blueCam = GameObject.Find("BlueCam");
		redCam = GameObject.Find("RedCam");
		var actionMap = playerControls.FindActionMap("Main Controls");
		moveAction = actionMap.FindAction("Movement");
		
		moveAction.performed += OnMoveUpdate;
		moveAction.canceled += OnMoveUpdate;
		moveAction.Enable();

		jumpAction = actionMap.FindAction("Jump");
		jumpAction.performed += OnJumpUpdate;
		jumpAction.canceled += OnJumpUpdate;
		jumpAction.Enable();

		useAction = actionMap.FindAction("Use");
		useAction.performed += Interact;
		useAction.Enable();
		rb = GetComponent<Rigidbody>();
	}

	public void SlowMovement(float mod)
    {
		currentSpeedVal = mod;
    }

	public void ResetMoveSpeed()
    {
		currentSpeedVal = moveSpeed;
    }
	private void OnMoveUpdate(InputAction.CallbackContext context) {
		movementInput = context.ReadValue<Vector2>();

		movementInput = movementInput.normalized;
	}

	private void OnJumpUpdate(InputAction.CallbackContext context) {
		jumpInput = context.ReadValue<float>();
	}

	private void Interact(InputAction.CallbackContext context)
    {
		if (context.canceled)
			return;

		//Debug.Log("Movement.cs Interact");
		RaycastHit hit;
		Debug.DrawRay(blueCam.transform.position, blueCam.transform.forward, Color.blue, interactRange, false);
			if (Physics.Raycast(blueCam.transform.position, blueCam.transform.forward, out hit, interactRange) && context.performed)
			{
			Debug.Log("Hit: " + hit.transform.name);
				if (hit.transform.CompareTag("interactable"))
            {
				//Debug.Log("Sending Interact()");
				hit.transform.SendMessage("Interact");

            }
			}

		if (Physics.Raycast(redCam.transform.position, blueCam.transform.forward, out hit, interactRange) && context.performed)
		{
			Debug.Log("Hit: " + hit.transform.name);
			if (hit.transform.CompareTag("interactable"))
			{
				//Debug.Log("Sending Interact()");
				hit.transform.SendMessage("Interact");

			}
		}
	}

    private void OnTriggerStay(Collider other)
    {
		if (other.CompareTag("slowZone"))
        {
			Debug.Log("SlowZoneStay");
			if (moveSpeed - slowedPenalty < currentSpeedVal) // if movement speed minus the penalty is less than the current speed, then slow the player back down
				SlowMovement(moveSpeed - slowedPenalty);
        }
    }


    private void Update() {
		Vector3 movement = (transform.right * movementInput.x + transform.forward * movementInput.y);
		transform.position += movement * Time.deltaTime * currentSpeedVal;

		// if not being slowed, start recovering
		if (currentSpeedVal < moveSpeed)
			currentSpeedVal += Time.deltaTime;

		if (CheckJump()) {
			rb.AddForce(Vector3.up * jumpInput * jumpForce);
		}
	}

	private bool CheckJump() {
		return Physics.CheckSphere(feet.position, floorRange, ground);
	}
}
