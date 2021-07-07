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

    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutionIndex = 0;
        isFullscreen = Screen.fullScreen;

        PopulateSprites();
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
            //EventSystem.current.SetSelectedGameObject(btnResolutionUp.gameObject, new BaseEventData(EventSystem.current));
        }
        else if (resolutionIndex == resolutions.Length -1)
        {
            btnResolutionUp.interactable = false;
            //EventSystem.current.SetSelectedGameObject(btnResolutionDown.gameObject, new BaseEventData(EventSystem.current));
        }
        else 
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

        if (currentSFXVolume == -80)
        {
            btnSFXDown.interactable = false;
            //EventSystem.current.SetSelectedGameObject(btnSFXUp.gameObject, new BaseEventData(EventSystem.current));
        }
        else if (currentSFXVolume == 20)
        {
            btnSFXUp.interactable = false;
            //EventSystem.current.SetSelectedGameObject(btnSFXDown.gameObject, new BaseEventData(EventSystem.current));
        }
        else
        {
            btnSFXDown.interactable = true;
            btnSFXUp.interactable = true;
        }

        if (currentMusicVolume == -80)
        {
            btnMusicDown.interactable = false;
            //EventSystem.current.SetSelectedGameObject(btnMusicUp.gameObject, new BaseEventData(EventSystem.current));
        }
        else if (currentMusicVolume == 20)
        {
            btnMusicUp.interactable = false;
            //EventSystem.current.SetSelectedGameObject(btnMusicDown.gameObject, new BaseEventData(EventSystem.current));
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
}
