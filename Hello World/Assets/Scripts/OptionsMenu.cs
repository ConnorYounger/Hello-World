using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    [Header("Audio UI")]
    public Button btnVolumeUp;
    public Button btnVolumeDown;
    public Button btnSFXUp;
    public Button btnSFXDown;
    public Button btnApplyAudio;

    private int _volume, _sfx;
    
    [Header("Display UI")]
    public Button btnResolutionUp;
    public Button btnResolutionDown;
    public TMP_Text textResValue;
    public Button btnFullscreenOff;
    public Button btnFullscreenOn; 
    public Button btnApplyDisplay;

    private List<string> resolutions = new List<string>();
    private int resolutionIndex;
    private bool isFullscreen;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Resolution"))
        {
            resolutionIndex = 3;
        }
    }

    private void Start()
    {
        PopulateResolutions();
        UpdateTextElements();
    }

    private void UpdateTextElements()
    {
        textResValue.text = resolutions[resolutionIndex];
    }

    private void Update()
    {
    }

    private void PopulateResolutions()
    {
        resolutions.Add("1366x768");
        resolutions.Add("1536x864");
        resolutions.Add("1440x900");
        resolutions.Add("1920x1080");
        resolutions.Add("2560x1440");
    }

    public void SetVolume()
    {

    }

    public void SetSFX()
    {

    }
}
