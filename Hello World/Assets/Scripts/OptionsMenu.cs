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
    public Button btnMusicUp;
    public Button btnMusicDown;
    public Button btnSFXUp;
    public Button btnSFXDown;
    public Button btnApplyAudio;
    public Sprite filledSprite;
    public Sprite emptySprite;

    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;

    private float currentMusicVolume, currentSFXVolume;

    [Header("Audio Sprites")]
    public Image music10, music20, music30, music40, music50, music60, music70, music80, music90, music100;

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

        btnMusicUp.onClick.AddListener(delegate { SetMusicVolume(10f); });
        btnMusicDown.onClick.AddListener(delegate { SetMusicVolume(-10f); });

        btnSFXUp.onClick.AddListener(delegate { SetSFXVolume(10f); });
        btnSFXDown.onClick.AddListener(delegate { SetSFXVolume(-10f); });
    }

    public float GetMusicVolume()
    {
        float value;
        bool result = musicMixer.GetFloat("Music", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
    }

    public float GetSFXVolume()
    {
        float value;
        bool result = SFXMixer.GetFloat("SFX", out value);
        if (result)
        {
            return value;
        }
        else
        {
            return 0f;
        }
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
        else if (resolutionIndex == resolutions.Length -1)
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

        if (currentMusicVolume == -80)
        {
            btnMusicDown.interactable = false;
        }
        else if (currentMusicVolume == 20)
        {
            btnMusicUp.interactable = false;
        }
        else
        {
            btnMusicDown.interactable = true;
            btnMusicUp.interactable = true;
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

    //TODO: Test when audio is implemented!!!
    public void SetMusicVolume(float v)
    {
        currentMusicVolume = GetMusicVolume() + v;
        musicMixer.SetFloat("Music", currentMusicVolume);
        UpdateMusicSprites();
    }

    public void SetSFXVolume(float v)
    {
        currentSFXVolume = GetSFXVolume() + v;
        SFXMixer.SetFloat("SFX", currentSFXVolume);
        UpdateSFXSprites();
    }

    private void UpdateMusicSprites()
    {
        switch (currentMusicVolume)
        {
            case -80:

            default:
                break;
        }
    }

    private void UpdateSFXSprites()
    {

    }
}
