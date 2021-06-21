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
        if (other.GetComponent<Rigidbody>() && other.tag == "Object")
        {
            colliders.Add(other);

            SetParentBool(true);
        }
        else if (other.name == "SpawnBoxZone")
        {
            SetParentBool(true);
            parentHandObject.canSpawnObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Rigidbody>() && other.tag == "Object")
        {
            colliders.Remove(other);

            SetParentBool(false);
        }
        else if (other.name == "SpawnBoxZone")
        {
            SetParentBool(false);
            parentHandObject.canSpawnObject = false;
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
}
