using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObjectRemoveZone : MonoBehaviour
{
    public int itemsToWin = 10;
    private int currentItems;

    public int loseTimer = 60;
    private int currentTime;

    public MovingObjectBabyHand[] hands;

    private bool gameEnd;

    [Space()]
    public List<GameObject> objects;

    public float removeTime = 3;

    private void Start()
    {
        currentTime = loseTimer;
        StartCoroutine("LoseTimer");
    }

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

        currentItems++;

        if (currentItems >= itemsToWin)
            Win();
    }

    void RemoveObject()
    {
        GameObject ob = objects[0];

        objects.Remove(ob);
        Destroy(ob);
    }

    void Win()
    {
        Debug.Log("Player Win");

        StopHands();
    }

    void Lose()
    {
        Debug.Log("Player Lose");

        StopHands();
    }

    void StopHands()
    {
        foreach(MovingObjectBabyHand hand in hands)
        {
            hand.canMove = false;
        }

        gameEnd = true;
    }

    IEnumerator LoseTimer()
    {
        yield return new WaitForSeconds(1);

        if (!gameEnd)
        {
            currentTime--;

            if (currentTime <= 0)
                Lose();
            else
                StartCoroutine("LoseTimer");
        }
    }
}
