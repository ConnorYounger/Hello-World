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

    [Header("Cutscene Audio")]
    public AudioClip introAudio;
    public AudioClip winAudio;
    public AudioClip winAudio2;
    public float winAudio2Time = 2;
    public AudioClip loseAudio;
    [HideInInspector] public AudioSource audioSource;

    private void Start()
    {
        if (startPP)
            SetStartProfile();

        audioSource = gameObject.GetComponent<AudioSource>();

        StartCoroutine("StartExerciseWaitTime");

        if (audioSource)
        {
            audioSource.clip = introAudio;
            audioSource.Play();
        }
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

        if (audioSource)
        {
            audioSource.clip = winAudio;
            audioSource.Play();

            if (winAudio2)
                StartCoroutine("PlayWinAudio2");
        }
    }

    IEnumerator PlayWinAudio2()
    {
        yield return new WaitForSeconds(winAudio2Time);

        audioSource.clip = winAudio2;
        audioSource.Play();
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

        if (audioSource)
        {
            audioSource.clip = loseAudio;
            audioSource.Play();
        }
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
