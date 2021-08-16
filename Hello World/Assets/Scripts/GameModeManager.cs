using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameModeManager : MonoBehaviour
{
    [Header("Buttons")]
    public GameObject discoveryModeButton;
    public GameObject toyBoxModeButton;

    [Header("Discovery Mode")]
    public DiscoveryPlayer discoveryPlayer;
    public float exerciseIndex = 1;

    private bool discoveryModeDebug = false;

    private void OnEnable()
    {
        CheckGameMode();
    }

    private void Start()
    {
        //DebugMode();
    }

    void DebugMode()
    {
        if (discoveryModeDebug)
        {
            PlayerPrefs.SetString("gameMode", "Discovery");
        }
        else
        {
            PlayerPrefs.SetString("gameMode", "ToyBox");
        }
    }

    void CheckGameMode()
    {
        if(PlayerPrefs.GetString("gameMode") == "Discovery")
        {
            SetButton(discoveryModeButton);
        }
        else
        {
            SetButton(toyBoxModeButton);
        }
    }

    void SetButton(GameObject button)
    {
        button.SetActive(true);

        StartCoroutine("SelectButton", button);
    }

    IEnumerator SelectButton(GameObject button)
    {
        yield return new WaitForSeconds(0.2f);

        EventSystem.current.SetSelectedGameObject(button);
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void DiscoverySceneSwitch()
    {
        discoveryPlayer.exerciseIndex = exerciseIndex;

        discoveryPlayer.SavePlayer();

        SceneManager.LoadScene("F_Discovery");
    }
}
