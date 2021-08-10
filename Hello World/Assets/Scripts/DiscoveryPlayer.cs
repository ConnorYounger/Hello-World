using UnityEngine;

public class DiscoveryPlayer : MonoBehaviour
{
    public float exerciseIndex;

    public void SavePlayer()
    {
        SaveSystem.SavePlayer(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        exerciseIndex = data.exerciseIndex;
    }
}