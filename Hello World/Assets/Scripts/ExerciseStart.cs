using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;

public class ExerciseStart : MonoBehaviour
{
    [Header("Exercise Start")]
    public float startWaitTime;
    public GameObject dialoguePanel;
    public GameObject startButtonUI;

    public bool setStartPP = true;
    public PostProcessProfile startPP;
    public PostProcessProfile normalPP;

    public PostProcessVolume pPVolume;

    [Header("UI Elements")]
    public GameObject[] gamePlayCanvases;

    [Header("Cutscene Cameras")]
    public GameObject introCamera;
    public GameObject transitionCamera;
    public GameObject winCamera;
    public GameObject loseCamera;
    public bool gamePlayCamera;
    public float playCamDelay = 1;
    public GameObject[] hiddenObjects;

    private void Start()
    {
        if (startPP)
            SetStartProfile();

        StartCoroutine("StartExerciseWaitTime");
    }

    IEnumerator StartExerciseWaitTime()
    {
        yield return new WaitForSeconds(startWaitTime);

        startButtonUI.SetActive(true);

        if (dialoguePanel)
            dialoguePanel.SetActive(true);

        if(startButtonUI.GetComponent<Button>())
            EventSystem.current.SetSelectedGameObject(startButtonUI);
    }

    public void SetStartProfile()
    {
        pPVolume.profile = startPP;

        SetCanvases(false);
    }

    public void StartExercise()
    {
        pPVolume.profile = normalPP;

        startButtonUI.SetActive(false);

        if (dialoguePanel)
            dialoguePanel.SetActive(false);

        if (introCamera && transitionCamera)
        {
            transitionCamera.SetActive(true);
            introCamera.SetActive(false);

            if (gamePlayCamera)
                StartCoroutine("PlayTransitionCutscene");
        }

        SetCanvases(true);
    }

    IEnumerator PlayTransitionCutscene()
    {
        yield return new WaitForSeconds(playCamDelay);

        SetHiddenObjects(false);

        transitionCamera.SetActive(false);
    }

    public void PlayWinCutscene()
    {
        if (winCamera)
            winCamera.SetActive(true);

        if (introCamera && transitionCamera)
        {
            transitionCamera.SetActive(false);
            introCamera.SetActive(false);
        }

        SetHiddenObjects(true);
    }

    public void PlayLoseCutscene()
    {
        if (loseCamera)
            loseCamera.SetActive(true);

        if (introCamera && transitionCamera)
        {
            transitionCamera.SetActive(false);
            introCamera.SetActive(false);
        }

        SetHiddenObjects(true);
    }

    void SetHiddenObjects(bool value)
    {
        if (hiddenObjects.Length > 0)
        {
            foreach (GameObject ob in hiddenObjects)
            {
                ob.SetActive(value);
            }
        }
    }

    void SetCanvases(bool value)
    {
        foreach(GameObject canvas in gamePlayCanvases)
        {
            if (canvas.GetComponent<Canvas>())
                canvas.GetComponent<Canvas>().enabled = value;
            else
                canvas.SetActive(value);
        }
    }
}
