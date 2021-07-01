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

    private Resolution[] resolutions;
    private List<string> resolutionsText = new List<string>();
    private int resolutionIndex;
    private bool isFullscreen;

    private void Awake()
    {
        if (!PlayerPrefs.HasKey("Resolution"))
        {
            resolutionIndex = 3;
        }
        if (!PlayerPrefs.HasKey("Fullscreen"))
        {
            isFullscreen = true;
        }
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        PopulateResolutions();
        UpdateTextElements();

        btnResolutionDown.onClick.AddListener(delegate { UpdateResolution(-1); });
        btnResolutionUp.onClick.AddListener(delegate { UpdateResolution(1); });
        btnFullscreenOff.onClick.AddListener(ToggleFullscreen);
        btnApplyDisplay.onClick.AddListener(SaveDisplayOptions);
    }

    private void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
    }

    private void SaveDisplayOptions()
    {
        switch (resolutionIndex)
        {
            case 0:
                PlayerPrefs.SetInt("Resolution", 0);
                RefreshResolution();
                RefreshFullscreen();
                break;
        }
    }

    private void RefreshFullscreen()
    {
        Screen.fullScreen = isFullscreen;
    }

    private void RefreshResolution()
    {
        //Screen.width = 
            //Screen.height
    }

    private void UpdateResolution(int v)
    {
        resolutionIndex = resolutionIndex + v;
        UpdateTextElements();
    }

    private void UpdateTextElements()
    {
        textResValue.text = resolutionsText[resolutionIndex];
    }

    private void Update()
    {
        if (resolutionIndex == 0)
        {
            btnResolutionDown.interactable = false;
        }
        else if (resolutionIndex == 4)
        {
            btnResolutionUp.interactable = false;
        } else 
        { 
            btnResolutionDown.interactable = true; 
            btnResolutionUp.interactable = true; 
        }

        if (isFullscreen)
        {
            btnFullscreenOn.interactable = false;
            btnFullscreenOff.interactable = true;
        }
        else if (!isFullscreen)
        {
            btnFullscreenOn.interactable = true;
            btnFullscreenOff.interactable = false;
        }
    }

    private void PopulateResolutions()
    {
        foreach (var item in resolutions)
        {
            resolutionsText.Add(item.ToString());
        }
        /*resolutions.Add("1366x768");
        resolutions.Add("1536x864");
        resolutions.Add("1440x900");
        resolutions.Add("1920x1080");
        resolutions.Add("2560x1440");*/
    }

    public void SetVolume()
    {

    }

    public void SetSFX()
    {

    }
}
