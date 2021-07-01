using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class OptionsMenu : MonoBehaviour
{
    [Header("Audio UI")]
    public Button btnVolumeUp;
    public Button btnVolumeDown;
    public Button btnSFXUp;
    public Button btnSFXDown;
    public Button btnApplyAudio;
    public Sprite filledSprite;
    public Sprite emptySprite;

    public AudioMixer audioMixer;

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

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionIndex = 0;
        isFullscreen = Screen.fullScreen;

        PopulateResolutions();
        UpdateTextElements();

        btnResolutionDown.onClick.AddListener(delegate { UpdateResolution(-1); });
        btnResolutionUp.onClick.AddListener(delegate { UpdateResolution(1); });
        btnFullscreenOff.onClick.AddListener(ToggleFullscreen);
        btnFullscreenOn.onClick.AddListener(ToggleFullscreen);
        btnApplyDisplay.onClick.AddListener(SaveDisplayOptions);

        //_volume = audioMixer.GetFloat("Music");

        btnVolumeUp.onClick.AddListener(delegate { UpdateVolume(10); });
        btnVolumeDown.onClick.AddListener(delegate { UpdateVolume(-10); });
    }

    private void UpdateVolume(int v)
    {
        audioMixer.SetFloat("Music", v);
    }

    private void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
    }

    private void SaveDisplayOptions()
    {
        SetResolution();
        RefreshFullscreen();
    }

    private void RefreshFullscreen()
    {
        Screen.fullScreen = isFullscreen;
    }

    private void SetResolution()
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
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
        else if (resolutionIndex == resolutions.Length)
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
        for (int i  = 0; i < resolutions.Length; i++)
        {
            var res = resolutions[i].width + "x" + resolutions[i].height;
            resolutionsText.Add(res);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                resolutionIndex = i;
            }
        }
    }

    public void SetVolume()
    {

    }

    public void SetSFX()
    {

    }
}
