using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObjectBox : MonoBehaviour
{
    public MovingObjectBabyHand rightHand;
    public GameObject[] spawnableObjects;

    private bool canSpawnObject = true;

    public GameObject SpawnObject()
    {
        if(spawnableObjects.Length > 0 && canSpawnObject)
        {
            int rand = Random.Range(0, spawnableObjects.Length);
            GameObject objectToSpawn = Instantiate(spawnableObjects[rand], transform.position, transform.rotation);

            canSpawnObject = false;

            Debug.Log("Spawn Object");

            return objectToSpawn;
        }
        else
        {
            Debug.Log("No Object");

            return null;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "PlayerHand")
        {
            rightHand.canPickUpObject = true;
            rightHand.canSpawnObject = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "PlayerHand")
        {
            rightHand.canPickUpObject = false;
            rightHand.canSpawnObject = false;
        }
    }

    public IEnumerator CanSpawnObject()
    {
        yield return 60;

        canSpawnObject = true;
    }
}
