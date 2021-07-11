using TMPro;
using UnityEngine;

public class DiscoveryPlayer : MonoBehaviour
{
    //public string babyName;
    //public string babyModel;
    public float exerciseIndex;
    public string cardIndex;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        //babyName = data.babyName;
        //babyModel = data.babyModel;
        exerciseIndex = data.exerciseIndex;
        cardIndex = data.cardIndex;
    }
}
