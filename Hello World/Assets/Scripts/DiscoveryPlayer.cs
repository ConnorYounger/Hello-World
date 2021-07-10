using TMPro;
using UnityEngine;

public class DiscoveryPlayer : MonoBehaviour
{
    //public string babyName;
    //public string babyModel;
    public int exerciseIndex;

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
    }

    //testing
    private void Update()
    {/*
        GameObject.Find("name").GetComponent<TMP_Text>().text = babyName;
        GameObject.Find("model").GetComponent<TMP_Text>().text = babyModel;
        GameObject.Find("exercise").GetComponent<TMP_Text>().text = exerciseIndex.ToString();*/
    }
}
