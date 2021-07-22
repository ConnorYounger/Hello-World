using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ParentNarrative : MonoBehaviour
{
    #region variables
    [System.Serializable]
    public struct textElement
    {
        [Tooltip("Start delay time")] public float startTime;
        [Tooltip("0 will keep the text up until tolled otherwise")] public float displayTime;
        public AudioClip voiceClip;
        [TextArea(2, 5)]public string text;
    }

    [Header("Parent Variables")]
    public AudioSource audioSource;
    public TMP_Text speachText;

    [Header("Narrative Elements")]
    public textElement introText;
    public textElement winText;
    public textElement loseText;

    [Space()]
    public bool playCustomDialouge;
    public textElement[] sucessDialougeTexts;
    public textElement[] encouragingDialougeTexts;
    public bool randomizeEncouragingDialouges;
    private int enPlayCounter;

    [Space()]
    public textElement[] failDialougeTexts;
    public bool playRandomFail;
    private int playCounter;
    #endregion

    private void Start()
    {
        StartCoroutine("ExecuteNarrativeElement", introText);
    }

    public IEnumerator ExecuteNarrativeElement(textElement t)
    {
        yield return new WaitForSeconds(t.startTime);

        if (t.voiceClip)
        {
            audioSource.clip = t.voiceClip;
            audioSource.Play();
        }

        if (speachText)
        {
            speachText.text = t.text;
            speachText.enabled = true;
        }

        yield return new WaitForSeconds(t.displayTime);

        if(t.displayTime != 0)
        {
            if (speachText)
                speachText.enabled = false;
        }
    }

    public void NarrativeElement(textElement t)
    {
        if (playCustomDialouge)
        {
            StopCoroutine("ExecuteNarrativeElement");
            StartCoroutine("ExecuteNarrativeElement", t);
        }
        else
        {
            PlayEncouragingDialouge();
        }
    }

    void PlayEncouragingDialouge()
    {
        if(randomizeEncouragingDialouges)
        {
            int rand = Random.Range(0, encouragingDialougeTexts.Length);
            PlayNarativeElement(encouragingDialougeTexts[rand]);
        }
        else
        {
            PlayNarativeElement(encouragingDialougeTexts[enPlayCounter]);

            enPlayCounter++;

            if (enPlayCounter >= encouragingDialougeTexts.Length)
                enPlayCounter = 0;
        }
    }

    void PlayNarativeElement(textElement t)
    {
        StopCoroutine("ExecuteNarrativeElement");
        StartCoroutine("ExecuteNarrativeElement", t);
    }

    public void PlayFailNarrativeElement()
    {
        if (playRandomFail)
        {
            int rand = Random.Range(0, failDialougeTexts.Length);
            PlayNarativeElement(failDialougeTexts[rand]);
        }
        else
        {
            PlayNarativeElement(failDialougeTexts[playCounter]);

            playCounter++;

            if (playCounter >= failDialougeTexts.Length)
                playCounter = 0;
        }
    }
}
