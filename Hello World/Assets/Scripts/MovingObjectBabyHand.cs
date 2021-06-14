using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovingObjectBabyHand : MonoBehaviour
{
    public bool rightHand = true;

    [HideInInspector] public bool canPickUpObject = true;
     public bool canSpawnObject;

    public float maxDistance = 50;
    public float movementSpeed = 1;

    public GameObject handObject;
    public GameObject otherHandObject;
    private GameObject heldObject;
    private GameObject spawnBox;
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
        spawnBox = GameObject.Find("SpawnBoxZone");
    }

    void Update()
    {
        HandMovement();
        OtherHandCollision();
        SpawnNewObject();

        Debug.Log(Time.deltaTime.ToString() + " " + canSpawnObject + " / " + canPickUpObject + " / " + heldObject);
    }

    void SpawnNewObject()
    {
        //if(canSpawnObject && !heldObject)
        //{
        //    //PickUpObject(spawnBox.GetComponent<SpawnObjectBox>().SpawnObject());
        //}
    }

    void OtherHandCollision()
    {
        if(otherHandObject && Vector3.Distance(handObject.transform.position, otherHandObject.transform.position) < 0.2f)
        {
            Vector2 direction = handObject.transform.position - otherHandObject.transform.position;

            handObject.transform.Translate(direction * 2 * Time.deltaTime);
        }
    }

    public void PickUpObject(GameObject obj)
    {
        if(obj != null)
        {
            heldObject = obj;
            heldObject.transform.parent = handObject.transform;
            heldObject.transform.position = handPickUpCollision.transform.position;

            heldObject.GetComponent<Rigidbody>().isKinematic = true;
            handPickUpCollision.gameObject.GetComponent<BoxCollider>().isTrigger = false;
        }
    }

    void DropObject()
    {
        heldObject.transform.parent = null;

        handPickUpCollision.gameObject.GetComponent<BoxCollider>().isTrigger = true;
        heldObject.GetComponent<Rigidbody>().isKinematic = false;

        heldObject = null;

        if (rightHand)
        {
            spawnBox.GetComponent<SpawnObjectBox>().StartCoroutine("CanSpawnObject");
        }
    }

    void PickUpObject(float value)
    {
        if (value >= 1 && canPickUpObject && !heldObject)
        {
            if (canSpawnObject)
            {
                Debug.Log("Try to spawn object");

                PickUpObject(spawnBox.GetComponent<SpawnObjectBox>().SpawnObject());

                Debug.Log("Try to spawn object");
            }
            else
            {
                Debug.Log("Pick up Object");

                handPickUpCollision.PickUpObject();
            }
        }
        else if (heldObject)
        {
            DropObject();
        }
        else if (canSpawnObject && !heldObject)
        {
            //PickUpObject(spawnBox.GetComponent<SpawnObjectBox>().SpawnObject());
        }
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
