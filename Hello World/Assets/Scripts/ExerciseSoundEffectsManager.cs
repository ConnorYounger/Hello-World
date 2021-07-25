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

    public List<AudioSource> createdSounds;

    public bool randomisSoundCollections;
    private int currentSucessSound;
    private int currentFailSound;

    [Header("Background Music")]
    public AudioClip musicTrack;
    private AudioSource musicAudioSource;
    public float musicVolume = 0.7f;
    public float fadeOutMultipier = 1;
    private bool fadeOutMusic;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        if (musicTrack)
            CreateSound(musicTrack, musicVolume, true);

        if (musicAudioSource && fadeOutMusic)
            MusicFadeOut();
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

        CreateSound(babyCrySounds[rand], 0.7f, true);
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

    void CreateSound(AudioClip audioClip, float volume,bool loop)
    {
        GameObject oj = Instantiate(new GameObject(), transform.position, transform.rotation);
        AudioSource a = oj.AddComponent<AudioSource>();
        createdSounds.Add(a);
        a.clip = audioClip;
        a.loop = loop;
        a.volume = volume;
        a.Play();

        if (audioClip == musicTrack)
        {
            musicAudioSource = a;
            oj.name = "Music Audio Source EGO";
        }
    }

    public void FadeOutMusic()
    {
        fadeOutMusic = true;
    }

    void MusicFadeOut()
    {
        if(musicAudioSource.volume > 0)
        {
            musicAudioSource.volume -= fadeOutMultipier * Time.deltaTime;
        }
    }
}
