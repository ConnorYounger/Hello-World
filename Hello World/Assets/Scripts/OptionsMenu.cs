using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.EventSystems;

public class OptionsMenu : MonoBehaviour
{
    #region Variables
    [Header("Audio UI")]
    public Button btnMusicUp;
    public Button btnMusicDown;
    public Button btnSFXUp;
    public Button btnSFXDown;
    public Button btnApplyAudio;
    public Sprite filledSprite;
    public Sprite emptySprite;
    public Button btnAudioBack;

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

    private List<Image> musicSprites = new List<Image>();
    private List<Image> sfxSprites = new List<Image>();

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
    #endregion

    private void Awake()
    {
    }

    private void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            currentMusicVolume = PlayerPrefs.GetFloat("MusicVolume");
            currentSFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        musicMixer.SetFloat("Music", currentMusicVolume);
        SFXMixer.SetFloat("SFX", currentSFXVolume);

        resolutions = Screen.resolutions;
        resolutionIndex = 0;
        isFullscreen = Screen.fullScreen;

        PopulateSprites();
        PopulateResolutions();
        UpdateTextElements();
        UpdateMusicSprites();
        UpdateSFXSprites();

        btnResolutionDown.onClick.AddListener(ResolutionDown);
        btnResolutionUp.onClick.AddListener(ResolutionUp);
        btnFullscreenOff.onClick.AddListener(ToggleFullscreen);
        btnFullscreenOn.onClick.AddListener(ToggleFullscreen);
        btnApplyDisplay.onClick.AddListener(SaveDisplayOptions);

        btnMusicUp.onClick.AddListener(MusicVolumeUp);
        btnMusicDown.onClick.AddListener(MusicVolumeDown);

        btnSFXUp.onClick.AddListener(SFXVolumeUp);
        btnSFXDown.onClick.AddListener(SFXVolumeDown);
        btnAudioBack.onClick.AddListener(SaveAudioSettings);

    }

    private void Update()
    {
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

    #region Audio
    private void SaveAudioSettings()
    {
        Debug.Log("Save audio to Prefs");
        PlayerPrefs.SetFloat("MusicVolume", currentMusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", currentSFXVolume);
        PlayerPrefs.Save();
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

    //TODO: Test when audio is implemented!!!
    public void MusicVolumeUp()
    {
        if (currentMusicVolume != 20)
        {
            currentMusicVolume = GetMusicVolume() + 10;
            musicMixer.SetFloat("Music", currentMusicVolume);
            UpdateMusicSprites();
        }
    }

    public void MusicVolumeDown()
    {
        if (currentMusicVolume != -80)
        {
            currentMusicVolume = GetMusicVolume() - 10;
            musicMixer.SetFloat("Music", currentMusicVolume);
            UpdateMusicSprites();
        }
    }

    public void SFXVolumeUp()
    {
        if (currentSFXVolume != 20)
        {
            currentSFXVolume = GetSFXVolume() + 10;
            SFXMixer.SetFloat("SFX", currentSFXVolume);
            UpdateSFXSprites();
        }
    }

    public void SFXVolumeDown()
    {
        if (currentSFXVolume != -80)
        {
            currentSFXVolume = GetSFXVolume() - 10;
            SFXMixer.SetFloat("SFX", currentSFXVolume);
            UpdateSFXSprites();
        }
    }

    private void PopulateSprites()
    {
        musicSprites.Add(music10);
        musicSprites.Add(music20);
        musicSprites.Add(music30);
        musicSprites.Add(music40);
        musicSprites.Add(music50);
        musicSprites.Add(music60);
        musicSprites.Add(music70);
        musicSprites.Add(music80);
        musicSprites.Add(music90);
        musicSprites.Add(music100);

        sfxSprites.Add(sfx10);
        sfxSprites.Add(sfx20);
        sfxSprites.Add(sfx30);
        sfxSprites.Add(sfx40);
        sfxSprites.Add(sfx50);
        sfxSprites.Add(sfx60);
        sfxSprites.Add(sfx70);
        sfxSprites.Add(sfx80);
        sfxSprites.Add(sfx90);
        sfxSprites.Add(sfx100);
    }

    private void UpdateMusicSprites()
    {
        switch (currentMusicVolume)
        {
            case -80:
                for (int i = 0; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -70:
                for (int i = 0; i < 1; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 1; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -60:
                for (int i = 0; i < 2; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 2; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -50:
                for (int i = 0; i < 3; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 3; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -40:
                for (int i = 0; i < 4; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 4; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -30:
                for (int i = 0; i < 5; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 5; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -20:
                for (int i = 0; i < 6; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 6; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case -10:
                for (int i = 0; i < 7; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 7; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case 0:
                for (int i = 0; i < 8; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 8; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case 10:
                for (int i = 0; i < 9; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }

                for (int i = 9; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = emptySprite;
                }
                break;
            case 20:
                for (int i = 0; i < musicSprites.Count; i++)
                {
                    musicSprites[i].sprite = filledSprite;
                }
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
                for (int i = 0; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -70:
                for (int i = 0; i < 1; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 1; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -60:
                for (int i = 0; i < 2; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 2; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -50:
                for (int i = 0; i < 3; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 3; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -40:
                for (int i = 0; i < 4; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 4; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -30:
                for (int i = 0; i < 5; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 5; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -20:
                for (int i = 0; i < 6; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 6; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case -10:
                for (int i = 0; i < 7; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 7; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case 0:
                for (int i = 0; i < 8; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 8; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case 10:
                for (int i = 0; i < 9; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }

                for (int i = 9; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = emptySprite;
                }
                break;
            case 20:
                for (int i = 0; i < sfxSprites.Count; i++)
                {
                    sfxSprites[i].sprite = filledSprite;
                }
                    break;
            default:
                break;
        }
    }
    #endregion

    #region Display
    private void ToggleFullscreen()
    {
        isFullscreen = !isFullscreen;
        EventSystem.current.SetSelectedGameObject(btnApplyDisplay.gameObject, new AxisEventData(EventSystem.current));
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

    private void ResolutionUp()
    {
        if (resolutionIndex != resolutions.Length - 1)
        {
            resolutionIndex = resolutionIndex + 1;
            UpdateTextElements();
        }
    }
    
    private void ResolutionDown()
    {
        if (resolutionIndex != 0)
        {
            resolutionIndex = resolutionIndex - 1;
            UpdateTextElements();
        }
    }

    private void UpdateTextElements()
    {
        textResValue.text = resolutionsText[resolutionIndex];
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
    #endregion
}
