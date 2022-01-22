using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;

public class MonsterAI : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Animator anim;
    public float atkRange;
    [SerializeField] Transform playerDummy;
    [SerializeField] private float speed;
    [SerializeField] private float speedExponent;
    [SerializeField] private float speedLimit;
    NavMeshAgent nma;

    [SerializeField] private InputActionAsset playerControls;
    private InputAction scanAction;
    private float scanValue;

    private void Awake() {
        var actionMap = playerControls.FindActionMap("Main Controls");
        scanAction = actionMap.FindAction("Scan");

        scanAction.performed += OnScanChange;
        scanAction.canceled += OnScanChange;
        scanAction.Enable();
    }
    
    private void OnScanChange(InputAction.CallbackContext context) {
        IncreaseSpeed();
    }
    
    void Start()
    {
        TryGetComponent<Animator>(out anim);
        TryGetComponent<NavMeshAgent>(out nma);
        InvokeRepeating("NavTick", 1f, 1f);
        SetSpeed();
    }

    void NavTick()
    {
        nma.SetDestination(playerDummy.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, playerDummy.position) <= atkRange)
            anim.SetBool("inRange", true);
        else
            anim.SetBool("inRange", false);
    }

    private void SetSpeed() {
       nma.speed = speed; 
    }

    private void IncreaseSpeed() {
        if (speed < speedLimit)
        speed = Mathf.Pow(speed, speedExponent);
        SetSpeed();
    }
}
