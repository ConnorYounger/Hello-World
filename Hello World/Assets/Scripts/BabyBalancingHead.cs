using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBalancingHead : MonoBehaviour
{
    public BabyBalancing babyBalancingScript;
    public Exercise6BabyMovement babyMovementScript;

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Floor" && babyBalancingScript)
            babyBalancingScript.BabyFell();
        else if (other.name == "WinZone" && babyMovementScript)
            babyMovementScript.Exersise6Win();
    }
}
