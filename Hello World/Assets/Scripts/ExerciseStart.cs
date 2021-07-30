using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering.PostProcessing;

public class ExerciseStart : MonoBehaviour
{
    [Header("Exercise Start")]
    public float startWaitTime;
    public GameObject startButtonUI;

    public bool setStartPP = true;
    public PostProcessProfile startPP;
    public PostProcessProfile normalPP;

    public PostProcessVolume pPVolume;

    [Header("UI Elements")]
    public GameObject[] gamePlayCanvases;

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

        SetCanvases(true);
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
