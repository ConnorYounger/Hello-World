using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ExcersiseAudioMix : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer SFXMixer;
    private float currentMusicVolume, currentSFXVolume;
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            currentMusicVolume = PlayerPrefs.GetFloat("MusicVolume");
            currentSFXVolume = PlayerPrefs.GetFloat("SFXVolume");
        }
        musicMixer.SetFloat("Music", currentMusicVolume);
        SFXMixer.SetFloat("SFX", currentSFXVolume);
    }
    private void SaveAudioSettings()
    {
        Debug.Log("Save audio to Prefs");
        PlayerPrefs.SetFloat("MusicVolume", currentMusicVolume);
        PlayerPrefs.SetFloat("SFXVolume", currentSFXVolume);
        PlayerPrefs.Save();
    }

}
