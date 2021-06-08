using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandPickUpCollision : MonoBehaviour
{
    public MovingObjectBabyHand parentHandObject;

    public List<Collider> colliders;

    void Start()
    {
        colliders = new List<Collider>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            colliders.Add(other);

            //other.GetComponent<Rigidbody>().isKinematic = true;

            SetParentBool(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>())
        {
            colliders.Remove(other);

            //other.GetComponent<Rigidbody>().isKinematic = false;

            SetParentBool(false);
        }
    }

    void SetParentBool(bool value)
    {
        parentHandObject.canPickUpObject = value;
    }

    public void PickUpObject()
    {
        parentHandObject.PickUpObject(colliders[colliders.Count - 1].gameObject);
    }

    void Update()
    {
        
    }
}
