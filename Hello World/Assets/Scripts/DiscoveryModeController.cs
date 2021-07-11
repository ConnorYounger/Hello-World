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
        player.GetComponent<DiscoveryPlayer>().LoadPlayer();

        LoadIndexData();
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
                LoadScene("Exercise 1.1");
                break;
        }
    }

    private void ShowMilestoneCard()
    {
        switch (cardIndex)
        {
            case "1In":
                stage1In.enabled = true;
                break;
            case "1Out":
                stage1Out.enabled = true;
                break;
            case "2In":
                stage2In.enabled = true;
                break;
            case "2Out":
                stage2Out.enabled = true;
                break;
            case "3In":
                stage3In.enabled = true;
                break;
            case "3Out":
                stage3Out.enabled = true;
                break;
            case "4In":
                stage4In.enabled = true;
                break;
            case "4Out":
                stage4Out.enabled = true;
                break;
            case "5In":
                stage5In.enabled = true;
                break;
            case "5Out":
                stage5Out.enabled = true;
                break;
            case "6In":
                stage6In.enabled = true;
                break;
            default:
                stage1In.enabled = true;
                break;
        }
    }
    private void LoadScene(string v)
    {
        SceneManager.LoadScene(v);
    }

    private void LoadIndexData()
    {
        exerciseIndex = player.GetComponent<DiscoveryPlayer>().exerciseIndex;
        cardIndex = player.GetComponent<DiscoveryPlayer>().cardIndex;
    }
}
