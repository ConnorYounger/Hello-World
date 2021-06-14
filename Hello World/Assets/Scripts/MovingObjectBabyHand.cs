using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingObjectBabyHand : MonoBehaviour
{
    public bool rightHand = true;

    [HideInInspector] public bool canPickUpObject = true;

    public float maxDistance = 50;
    public float movementSpeed = 1;

    public GameObject handObject;
    private GameObject heldObject;
    public HandPickUpCollision handPickUpCollision;

    private Vector3 startionPos;
    private Vector2 move;

    private MiniGameInputs controls;

    private void Awake()
    {
        controls = new MiniGameInputs();

        if (rightHand)
        {
            controls.HoldingObjects.RightHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.HoldingObjects.RightHandMovement.canceled += ctx => move = Vector2.zero;

            controls.HoldingObjects.RightHandGrab.performed += ctx => PickUpObject(ctx.ReadValue<float>());
            //controls.HoldingObjects.RightHandGrab.canceled += ctx => PickUpObject(0);
        }
        else
        {
            controls.HoldingObjects.LeftHandMovement.performed += ctx => move = ctx.ReadValue<Vector2>();
            controls.HoldingObjects.LeftHandMovement.canceled += ctx => move = Vector2.zero;

            controls.HoldingObjects.LeftHandGrab.performed += ctx => PickUpObject(ctx.ReadValue<float>());
            //controls.HoldingObjects.LeftHandGrab.canceled += ctx => PickUpObject(0);
        }
    }

    private void OnEnable()
    {
        controls.HoldingObjects.Enable();
    }

    private void OnDisable()
    {
        controls.HoldingObjects.Disable();
    }

    void Start()
    {
        startionPos = handObject.transform.position;
    }

    void Update()
    {
        HandMovement();
    }

    public void PickUpObject(GameObject obj)
    {
        heldObject = obj;
        heldObject.transform.parent = handObject.transform;
        heldObject.transform.position = handPickUpCollision.transform.position;

        heldObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    void DropObject()
    {
        heldObject.transform.parent = null;

        heldObject.GetComponent<Rigidbody>().isKinematic = false;

        heldObject = null;
    }

    void PickUpObject(float value)
    {
        if (value >= 1 && canPickUpObject && !heldObject)
        {
            handPickUpCollision.PickUpObject();
        }
        else if (heldObject)
        {
            DropObject();
        }

        Debug.Log(value);
    }

    void HandMovement()
    {
        if(Vector3.Distance(handObject.transform.position, startionPos) < maxDistance)
        {
            Vector2 movement = new Vector2(move.x, move.y) * Time.deltaTime * movementSpeed;
            handObject.transform.Translate(movement);
        }
        else
        {
            handObject.transform.position = Vector3.Slerp(handObject.transform.position, startionPos, .5f * Time.deltaTime);
        }
    }
}
