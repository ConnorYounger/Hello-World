using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ExerciseStart : MonoBehaviour
{
    public bool setStartPP = true;
    public PostProcessProfile startPP;
    public PostProcessProfile normalPP;

    public PostProcessVolume pPVolume;

    [Header("UI Elements")]
    public Canvas[] gamePlayCanvases;

    private void Start()
    {
        if (startPP)
            SetStartProfile();
    }

    public void SetStartProfile()
    {
        pPVolume.profile = startPP;

        SetCanvases(false);
    }

    public void SetNormalProfile()
    {
        pPVolume.profile = normalPP;

        SetCanvases(true);
    }

    void SetCanvases(bool value)
    {
        foreach(Canvas canvas in gamePlayCanvases)
        {
            canvas.enabled = value;
        }
    }
}
