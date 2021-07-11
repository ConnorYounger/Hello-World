using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public string babyName;
    //public string babyModel;
    public float exerciseIndex;
    public string cardIndex;

    public PlayerData(DiscoveryPlayer player)
    {
        //babyName = player.babyName;
        //babyModel = player.babyModel;
        exerciseIndex = player.exerciseIndex;
        cardIndex = player.cardIndex;
    }
}
