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
        for (int i = 0; i < colliders.Count; i++)
        {
            Debug.Log("Check List");

            if(other != colliders[i])
            {
                Debug.Log("Add " + other);

                colliders.Add(other);

                SetParentBool(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        List<Collider> allColliders = new List<Collider>();
        allColliders = colliders;

        foreach(Collider collider in allColliders)
        {
            if(other == collider)
            {
                colliders.Remove(other);

                SetParentBool(false);
            }
        }
    }

    void SetParentBool(bool value)
    {
        if (parentHandObject.rightHand)
        {
            parentHandObject.rightHandCanPickUp = value;
        }
        else
        {
            parentHandObject.leftHandCanPickUp = value;
        }
    }

    public void PickUpObject()
    {
        parentHandObject.PickUpObject(colliders[1].gameObject);
    }

    void Update()
    {
        
    }
}
