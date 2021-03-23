using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaController : CharaBehavior
{
    protected float inputAxis;
    [SerializeField] protected bool onJump;
    [SerializeField] protected KeyCode moveLeft;
    [SerializeField] protected KeyCode moveRight;
    [SerializeField] protected KeyCode jumpCode;

    protected InputMaster controls;

    private void Awake()
    {
        controls = new InputMaster();
        controls.Player.Movement.performed += ctx => inputAxis = ctx.ReadValue<float>();
        controls.Player.Movement.canceled += ctx => 
        {
            inputAxis = 0;
            anim.SetBool("walk", false);
        };
        controls.Player.Jump.performed += ctx => onJump = true;
    }

    private void Start()
    {
        Init();
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    void Update()
    {
        //// Move with GetKey
        //InputGetKeyMovement();

        //// Move with GetAxis
        //InputGetAxisMovement();

        Move(inputAxis);
        ModifyPhysic();
        //InputGetKeyJump();
        //InputGetAxisJump();
        InputActionJump();
        CheckGround();
    }

    public void InputGetKeyMovement()
    {
        if (Input.GetKey(moveLeft))
        {
            Move(-1);
        }
        if (Input.GetKey(moveRight))
        {
            Move(1);
        }
    }

    public void InputGetAxisMovement()
    {
        direction.x = Input.GetAxis("Horizontal");
        Move(direction.x);
    }

    public void InputGetKeyJump()
    {
        if (Input.GetKey(jumpCode) && CheckGround())
        {
            Jump();
        }
    }

    public void InputGetAxisJump()
    {
        if (Input.GetAxis("Jump") == 1 && CheckGround())
        {
            Jump();
        }
    }

    public void InputActionJump()
    {
        if (onJump && CheckGround())
        {
            Jump();
        }
        onJump = false;
    }

}
