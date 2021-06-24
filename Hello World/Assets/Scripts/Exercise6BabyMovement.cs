using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exercise6BabyMovement : MonoBehaviour
{
    public float movementSpeed = 1;

    private MiniGameInputs controls;
    private Vector2 move;
    private Vector2 tilt;

    private void Awake()
    {
        controls = new MiniGameInputs();

        //controls.HoldingObjects.RightHandMovement.performed += ctx => tilt = ctx.ReadValue<Vector2>();

        controls.HoldingObjects.LeftHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
        //controls.HoldingObjects.LeftHandMovement.canceled += ctx => move = Vector2.zero;
    }

    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }

    private void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        Debug.Log(move);

        Vector3 movement = new Vector3(move.x, transform.position.y, move.y) * Time.deltaTime * movementSpeed;
        transform.Translate(transform.right * move.y * Time.deltaTime * movementSpeed);
    }
}
