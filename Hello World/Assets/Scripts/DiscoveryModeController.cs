using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoveryModeController : MonoBehaviour
{
    #region Variables
    public float exerciseIndex;
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

    private bool onCardIn;
    #endregion

    private void Start()
    {
        //LoadPlayer();
        onCardIn = true;
        ShowCardIn();

        btnBack.onClick.AddListener(delegate { LoadScene("Main"); });
        btnNext.onClick.AddListener(ContinueDiscovery);
    }

    private void ContinueDiscovery()
    {
        if (onCardIn)
        {
            ShowCardOut();
        } else
        {
            exerciseIndex += 1;
            LoadScene("Exercise " + exerciseIndex);
        }
    }

    private void LoadScene(string v)
    {
        SceneManager.LoadScene(v);
    }

    private void ShowCardIn()
    {
        switch (exerciseIndex)
        {
            case 1.1f:
                stage2In.enabled = true;
                break;
            case 2.1f:
                stage3In.enabled = true;
                break;
            case 3.1f:
                stage4In.enabled = true;
                break;
            case 4.1f:
                stage5In.enabled = true;
                break;
            case 5.1f:
                stage6In.enabled = true;
                break;
            default:
                stage1In.enabled = true;
                break;
        }
    }

    private void ShowCardOut()
    {
        switch (exerciseIndex)
        {
            case 1.1f:
                stage2Out.enabled = true;
                onCardIn = false;
                break;
            case 2.1f:
                stage3Out.enabled = true;
                onCardIn = false;
                break;
            case 3.1f:
                stage4Out.enabled = true;
                onCardIn = false;
                break;
            case 4.1f:
                stage5Out.enabled = true;
                onCardIn = false;
                break;
            case 5.1f:
                stage6Out.enabled = true;
                onCardIn = false;
                break;
            default:
                stage1Out.enabled = true;
                onCardIn = false;
                break;
        }
    }

    private void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        exerciseIndex = data.exerciseIndex;
    }
}
