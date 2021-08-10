using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DiscoveryModeController : MonoBehaviour
{
    #region Variables
    public GameObject player;
    public GameObject btnPanel;
    public Button btnBack;
    public Button btnNext;

    [Header("Milestone Pictures")]
    public GameObject month3;
    public GameObject month5;
    public GameObject month7;
    public GameObject month9;
    public GameObject month12;
   
    [Header("Milestone Text")]
    public TMP_Text text3m;
    public TMP_Text text5m;
    public TMP_Text text7m;
    public TMP_Text text9m;
    public TMP_Text text12m;

    private float exerciseIndex;
    private string sceneToLoad;
    #endregion

    private void Start()
    {
        player.GetComponent<DiscoveryPlayer>().LoadPlayer();

        UnloadObjects();
        LoadIndexData();
        UpdateDiscovery();

        btnBack.onClick.AddListener(delegate { LoadScene("Main"); });
        btnNext.onClick.AddListener(delegate { LoadScene(sceneToLoad); });

        StartCoroutine(DelayButtons());
    }

    private IEnumerator DelayButtons()
    {
        yield return new WaitForSeconds(10);

        btnPanel.SetActive(true);
        
        yield return new WaitForSeconds(.5f);

        EventSystem.current.SetSelectedGameObject(btnNext.gameObject);
    }

    private void UnloadObjects()
    {
        btnPanel.SetActive(false);

        month3.SetActive(false);
        month5.SetActive(false);
        month7.SetActive(false);
        month9.SetActive(false);
        month12.SetActive(false);

        text3m.enabled = false;
        text5m.enabled = false;
        text7m.enabled = false;
        text9m.enabled = false;
        text12m.enabled = false;
    }

    private void UpdateDiscovery()
    {
        switch (exerciseIndex)
        {
            case 1:
                text3m.enabled = true;
                month3.SetActive(true);
                sceneToLoad = "Workout";
                break;
            case 2:
                text5m.enabled = true;
                month5.SetActive(true);
                sceneToLoad = "The little one said";
                break;
            case 3:
                text7m.enabled = true;
                month7.SetActive(true);
                sceneToLoad = "Jelly on a plate";
                break;
            case 4:
                text9m.enabled = true;
                month9.SetActive(true);
                sceneToLoad = "Off you go";
                break;
            case 5:
                text12m.enabled = true;
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