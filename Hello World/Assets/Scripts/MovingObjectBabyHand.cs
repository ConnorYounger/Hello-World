using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    void Start()
    {
        startionPos = handObject.transform.position;
    }

    void Update()
    {
        if (rightHand)
        {
            RightHandInput();
            RightPickUpInput();
        }
        else
        {
            LeftHandInput();
            LeftPickUpInput();
        }
    }

    void RightPickUpInput()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (canPickUpObject && !heldObject)
            {
                handPickUpCollision.PickUpObject();
            }
            else if(heldObject)
            {
                DropObject();
            }
        }
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

    void LeftPickUpInput()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            if (canPickUpObject && !heldObject)
            {
                handPickUpCollision.PickUpObject();
            }
            else if (heldObject)
            {
                DropObject();
            }
        }
    }

    void RightHandInput()
    {
        if(Vector3.Distance(handObject.transform.position, startionPos) < maxDistance)
        {
            Vector3 rotation = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            handObject.transform.position += rotation * Time.deltaTime * movementSpeed;
        }
        else
        {
            handObject.transform.position = Vector3.Slerp(handObject.transform.position, startionPos, .5f * Time.deltaTime);
        }
    }

    // Right joystick
    void LeftHandInput()
    {
        if (Vector3.Distance(handObject.transform.position, startionPos) < maxDistance)
        {
            Vector3 rotation = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical"), 0);
            handObject.transform.position += rotation * Time.deltaTime * movementSpeed;
        }
        else
        {
            handObject.transform.position = Vector3.Slerp(handObject.transform.position, startionPos, .5f * Time.deltaTime);
        }
    }
}
