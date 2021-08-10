using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public float exerciseIndex;

    public PlayerData(DiscoveryPlayer player)
    {
        exerciseIndex = player.exerciseIndex;
    }
}