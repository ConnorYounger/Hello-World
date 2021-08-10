using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoveryModeController : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public float exerciseIndex;
    
    public Button btnBack;
    public Button btnNext;

    [Header("Milestone Pictures")]
    public GameObject month3;
    public GameObject month5;
    public GameObject month7;
    public GameObject month9;
    public GameObject month12;

    private string sceneToLoad;
    #endregion

    private void Start()
    {
        player.GetComponent<DiscoveryPlayer>().LoadPlayer();

        DeactivatePics();
        LoadIndexData();
        UpdateDiscovery();

        btnBack.onClick.AddListener(delegate { LoadScene("Main"); });
        btnNext.onClick.AddListener(delegate { LoadScene(sceneToLoad); });
    }

    private void DeactivatePics()
    {
        month3.SetActive(false);
        month5.SetActive(false);
        month7.SetActive(false);
        month9.SetActive(false);
        month12.SetActive(false);
    }

    private void UpdateDiscovery()
    {
        switch (exerciseIndex)
        {
            case 1:
                month3.SetActive(true);
                sceneToLoad = "Workout";
                break;
            case 2:
                month5.SetActive(true);
                sceneToLoad = "The little one said";
                break;
            case 3:
                month7.SetActive(true);
                sceneToLoad = "Jelly on a plate";
                break;
            case 4:
                month9.SetActive(true);
                sceneToLoad = "Off you go";
                break;
            case 5:
                month12.SetActive(true);
                sceneToLoad = "One small step";
                break;
            default:
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
    }
}