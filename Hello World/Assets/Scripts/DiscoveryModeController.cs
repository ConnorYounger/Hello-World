using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoveryModeController : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public float exerciseIndex;
    public string cardIndex;
    
    public Button btnBack;
    public Button btnNext;

    [Header("Stage Cards")]
    public Image stage1In;
    public Image stage1Out;
    public Image stage2In;
    public Image stage2Out;
    public Image stage3In;
    public Image stage3Out;
    public Image stage4In;
    public Image stage4Out;
    public Image stage5In;
    public Image stage5Out;
    public Image stage6In;
    public Image stage6Out;

    #endregion

    private void Start()
    {
        LoadPlayer();
        ShowMilestoneCard();

        btnBack.onClick.AddListener(delegate { LoadScene("Main"); });
        btnNext.onClick.AddListener(ContinueDiscovery);
    }

    private void ContinueDiscovery()
    {
        switch (cardIndex)
        {
            case "1In":
                LoadScene("Exercise 1.1");
                break;
            case "1Out":
                cardIndex = "2In";
                break;
            case "2In":
                LoadScene("Exercise 2.1");
                break;
            case "2Out":
                cardIndex = "3In";
                break;
            //Add more exercises
            default:
                break;
        }
    }

    private void ShowMilestoneCard()
    {
        switch (cardIndex)
        {
            case "1In":
                break;
            case "1Out":
                break;
            case "2In":
                break;
            case "2Out":
                break;
            case "3In":
                break;
            case "3Out":
                break;
            case "4In":
                break;
            case "4Out":
                break;
            case "5In":
                break;
            case "5Out":
                break;
            case "6In":
                break;
            default:
                break;
        }
    }
    private void LoadScene(string v)
    {
        SceneManager.LoadScene(v);
    }

    public void SavePlayer()
    {
        //SaveSystem.SavePlayer(this);
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        exerciseIndex = data.exerciseIndex;
        cardIndex = data.cardIndex;
    }
}
