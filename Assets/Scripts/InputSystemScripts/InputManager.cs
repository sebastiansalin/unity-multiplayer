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

    // Awake is called when the script instance is being loaded.
    void Awake() {
        playerInput = new PlayerControls();
        onFoot = playerInput.OnFoot;

        motor = GetComponent<PlayerMotor>();
        look = GetComponent<PlayerLook>();

        onFoot.Jump.performed += ctw => motor.Jump();
        
    }

    // Frame-rate independent FixedUpdate message for physics calculations. https://docs.unity3d.com/ScriptReference/MonoBehaviour.FixedUpdate.html
    void FixedUpdate() {
        // Tell the playermotor to move using the value from ouir movement action.
        motor.ProcessMove(onFoot.Movement.ReadValue<Vector2>());
    }
    
    private void LateUpdate() {
        Vector2 lookDirection = onFoot.Look.ReadValue<Vector2>();
        look.ProcessLook(lookDirection);
    }

    private void OnEnable() {
        onFoot.Enable();
    }

    private void OnDisable() {
        onFoot.Disable();
    }
}
