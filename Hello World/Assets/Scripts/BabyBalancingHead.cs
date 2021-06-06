using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBalancingHead : MonoBehaviour
{
    public BabyBalancing babyBalancingScript;

    private void OnTriggerEnter(Collider other)
    {
        babyBalancingScript.BabyFell();
    }
}
