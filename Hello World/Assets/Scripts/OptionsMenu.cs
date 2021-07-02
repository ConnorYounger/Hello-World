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
    public Image music10;
    public Image music20;
    public Image music30;
    public Image music40;
    public Image music50;
    public Image music60;
    public Image music70;
    public Image music80;
    public Image music90;
    public Image music100;
    public Image sfx10;
    public Image sfx20;
    public Image sfx30;
    public Image sfx40;
    public Image sfx50;
    public Image sfx60;
    public Image sfx70;
    public Image sfx80;
    public Image sfx90;
    public Image sfx100;

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
        UpdateMusicSprites();
        UpdateSFXSprites();

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
                music10.sprite = emptySprite;
                music20.sprite = emptySprite; 
                music30.sprite = emptySprite; 
                music40.sprite = emptySprite; 
                music50.sprite = emptySprite;
                music60.sprite = emptySprite; 
                music70.sprite = emptySprite; 
                music80.sprite = emptySprite;
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case -70:
                music10.sprite = filledSprite;

                music20.sprite = emptySprite;
                music30.sprite = emptySprite; 
                music40.sprite = emptySprite;
                music50.sprite = emptySprite;
                music60.sprite = emptySprite;
                music70.sprite = emptySprite;
                music80.sprite = emptySprite;
                music90.sprite = emptySprite;
                music100.sprite = emptySprite;
                break;
            case -60:
                music10.sprite = filledSprite;
                music20.sprite = filledSprite;

                music30.sprite = emptySprite; 
                music40.sprite = emptySprite;
                music50.sprite = emptySprite;
                music60.sprite = emptySprite;
                music70.sprite = emptySprite;
                music80.sprite = emptySprite;
                music90.sprite = emptySprite;
                music100.sprite = emptySprite;
                break;
            case -50:
                music10.sprite = filledSprite;
                music20.sprite = filledSprite;
                music30.sprite = filledSprite;
                
                music40.sprite = emptySprite; 
                music50.sprite = emptySprite;
                music60.sprite = emptySprite; 
                music70.sprite = emptySprite; 
                music80.sprite = emptySprite; 
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case -40:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite;
                music40.sprite = filledSprite; 

                music50.sprite = emptySprite;
                music60.sprite = emptySprite; 
                music70.sprite = emptySprite; 
                music80.sprite = emptySprite; 
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case -30:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite;
                music50.sprite = filledSprite;

                music60.sprite = emptySprite; 
                music70.sprite = emptySprite; 
                music80.sprite = emptySprite; 
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case -20:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite;
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite; 
                music50.sprite = filledSprite;
                music60.sprite = filledSprite;

                music70.sprite = emptySprite; 
                music80.sprite = emptySprite; 
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case -10:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite; 
                music50.sprite = filledSprite; 
                music60.sprite = filledSprite; 
                music70.sprite = filledSprite; 
                
                music80.sprite = emptySprite; 
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case 0:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite; 
                music50.sprite = filledSprite; 
                music60.sprite = filledSprite; 
                music70.sprite = filledSprite; 
                music80.sprite = filledSprite; 
                
                music90.sprite = emptySprite; 
                music100.sprite = emptySprite;
                break;
            case 10:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite; 
                music50.sprite = filledSprite; 
                music60.sprite = filledSprite; 
                music70.sprite = filledSprite; 
                music80.sprite = filledSprite; 
                music90.sprite = filledSprite; 
                
                music100.sprite = emptySprite;
                break;
            case 20:
                music10.sprite = filledSprite; 
                music20.sprite = filledSprite; 
                music30.sprite = filledSprite; 
                music40.sprite = filledSprite; 
                music50.sprite = filledSprite;
                music60.sprite = filledSprite; 
                music70.sprite = filledSprite; 
                music80.sprite = filledSprite;
                music90.sprite = filledSprite; 
                music100.sprite = filledSprite;
                break;
            default:
                break;
        }
    }

    private void UpdateSFXSprites()
    {
        switch (currentSFXVolume)
        {
            case -80:
                sfx10.sprite = emptySprite;
                sfx20.sprite = emptySprite;
                sfx30.sprite = emptySprite;
                sfx40.sprite = emptySprite;
                sfx50.sprite = emptySprite;
                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -70:
                sfx10.sprite = filledSprite;

                sfx20.sprite = emptySprite;
                sfx30.sprite = emptySprite;
                sfx40.sprite = emptySprite;
                sfx50.sprite = emptySprite;
                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -60:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;

                sfx30.sprite = emptySprite;
                sfx40.sprite = emptySprite;
                sfx50.sprite = emptySprite;
                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -50:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;

                sfx40.sprite = emptySprite;
                sfx50.sprite = emptySprite;
                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -40:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;

                sfx50.sprite = emptySprite;
                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -30:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;

                sfx60.sprite = emptySprite;
                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -20:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;
                sfx60.sprite = filledSprite;

                sfx70.sprite = emptySprite;
                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case -10:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;
                sfx60.sprite = filledSprite;
                sfx70.sprite = filledSprite;

                sfx80.sprite = emptySprite;
                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case 0:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;
                sfx60.sprite = filledSprite;
                sfx70.sprite = filledSprite;
                sfx80.sprite = filledSprite;

                sfx90.sprite = emptySprite;
                sfx100.sprite = emptySprite;
                break;
            case 10:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;
                sfx60.sprite = filledSprite;
                sfx70.sprite = filledSprite;
                sfx80.sprite = filledSprite;
                sfx90.sprite = filledSprite;

                sfx100.sprite = emptySprite;
                break;
            case 20:
                sfx10.sprite = filledSprite;
                sfx20.sprite = filledSprite;
                sfx30.sprite = filledSprite;
                sfx40.sprite = filledSprite;
                sfx50.sprite = filledSprite;
                sfx60.sprite = filledSprite;
                sfx70.sprite = filledSprite;
                sfx80.sprite = filledSprite;
                sfx90.sprite = filledSprite;
                sfx100.sprite = filledSprite;
                break;
            default:
                break;
        }
    }
}
