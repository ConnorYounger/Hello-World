using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObjectRemoveZone : MonoBehaviour
{
    public List<GameObject> objects;

    public float removeTime = 3;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Object" && other.GetComponent<Rigidbody>() && !other.GetComponent<Rigidbody>().isKinematic)
        {
            if (objects.Count > 0)
            {
                bool inList = false;

                foreach (GameObject ob in objects)
                {
                    if (other.gameObject == ob)
                    {
                        inList = true;
                    }

                    if (!inList)
                    {
                        AddedObject(other.gameObject);
                    }
                }
            }
            else
            {
                AddedObject(other.gameObject);
            }
        }
    }

    void AddedObject(GameObject ob)
    {
        objects.Add(ob);

        Invoke("RemoveObject", removeTime);
    }

    void RemoveObject()
    {
        GameObject ob = objects[0];

        objects.Remove(ob);
        Destroy(ob);
    }
}
