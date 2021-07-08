using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public string babyName;
    public string babyModel;
    public int exerciseIndex;

    public PlayerData(DiscoveryPlayer player)
    {
        babyName = player.babyName;
        babyModel = player.babyModel;
        exerciseIndex = player.exerciseIndex;
    }
}
