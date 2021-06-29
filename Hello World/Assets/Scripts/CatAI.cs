using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatAI : MonoBehaviour
{
    public GameObject player;

    public int state = 0;
    public float stateTime = 5;
    private float stateTimer;

    List<GameObject> sleepSpots;
    List<GameObject> NPCBabies;

    void Start()
    {
        sleepSpots = new List<GameObject>();
        NPCBabies = new List<GameObject>();

        sleepSpots.AddRange(GameObject.FindGameObjectsWithTag("CatSleepSpot"));
        sleepSpots.AddRange(GameObject.FindGameObjectsWithTag("NPCBaby"));

        if (!player)
        {
            player = GameObject.Find("Baby");
        }
    }

    void Update()
    {
        
    }
}
