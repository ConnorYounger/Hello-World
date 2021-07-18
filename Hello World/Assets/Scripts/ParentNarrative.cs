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
    public textElement[] sucessDialougeTexts;

    [Space()]
    public textElement[] failDialougeTexts;
    public bool playRandom;
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
        StopCoroutine("ExecuteNarrativeElement");
        StartCoroutine("ExecuteNarrativeElement", t);
    }

    public void PlayFailNarrativeElement()
    {
        if (playRandom)
        {
            int rand = Random.Range(0, failDialougeTexts.Length);
            NarrativeElement(failDialougeTexts[rand]);
        }
        else
        {
            NarrativeElement(failDialougeTexts[playCounter]);

            playCounter++;

            if (playCounter >= failDialougeTexts.Length)
                playCounter = 0;
        }
    }
}
