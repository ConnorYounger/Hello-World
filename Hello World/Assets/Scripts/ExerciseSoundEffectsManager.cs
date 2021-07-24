using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExerciseSoundEffectsManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Sounds")]
    public AudioClip[] sucessSounds;
    public AudioClip[] failSounds;
    public AudioClip winSound;
    public AudioClip loseSound;

    public AudioClip[] babyCrySounds;

    public bool randomisSoundCollections;
    private int currentSucessSound;
    private int currentFailSound;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySucessSound()
    {
        if (randomisSoundCollections)
        {
            int rand = Random.Range(0, sucessSounds.Length);

            PlaySound(sucessSounds[rand]);
        }
        else
        {
            PlaySound(sucessSounds[currentSucessSound]);

            currentSucessSound++;

            if (currentSucessSound >= sucessSounds.Length)
                currentSucessSound = 0;
        }
    }

    public void PlayFailSound()
    {
        if (randomisSoundCollections)
        {
            int rand = Random.Range(0, failSounds.Length);

            PlaySound(failSounds[rand]);
        }
        else
        {
            PlaySound(failSounds[currentFailSound]);

            currentFailSound++;

            if (currentFailSound >= failSounds.Length)
                currentFailSound = 0;
        }
    }

    public void PlayWinSound()
    {
        PlaySound(winSound);
    }

    public void PlayLoseSound()
    {
        PlaySound(loseSound);
    }

    public void PlayBabyCrySound()
    {
        int rand = Random.Range(0, babyCrySounds.Length);


    }

    void PlaySound(AudioClip audioClip)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
    }

    void PlaySound(AudioClip audioClip, bool loop)
    {
        audioSource.clip = audioClip;
        audioSource.Play();
        audioSource.loop = loop;
    }

}
