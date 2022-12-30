using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class InputManager : NetworkBehaviour
{

    private PlayerControls playerInput;
    private PlayerControls.OnFootActions onFoot;
    private PlayerMotor motor;
    private PlayerLook look;

    // Start is called before the first frame update
    void Awake() {
        playerInput = new PlayerControls();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctw => motor.Jump();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Tell the playermotor to move using the value from ouir movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    
    private void LateUpdate() {
        Vector2 looky = onFoot.Look.ReadValue<Vector2>();
        look.ProcessLook(looky);
        
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}
