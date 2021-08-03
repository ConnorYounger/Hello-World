using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuAudioManager : MonoBehaviour
{
    
    //Header("Cam Movements")]
    //public Button camShelf;
    //public Button camToybox;
    //public Button camCrib;
    //public Button camMat;
    //public Button camChanget;
    //public Button camDoor;

    //[Header("UI Buttons")]
    //public Button OptionChange;
    //public Button OptionSelect;
    //public Button Back;


    //[Header("Audio Clips")]
    //Camera Movement Clips//
    //public AudioClip clipShelf;
    //public AudioClip clipToybox;
    //public AudioClip clipCrib;
    //public AudioClip clipMat;
    //public AudioClip clipChanget;
    //public AudioClip clipDoor;
    //Button Selection Clips//
    //public AudioClip clipOptionChange;
    //public AudioClip clipOptionSelect;
    //public AudioClip clipBack;
    
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //camToybox.onClick.AddListener(delegate { PlayAudioClip(clipShelf); });
    }

    public void PlayAudioClip(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

}
