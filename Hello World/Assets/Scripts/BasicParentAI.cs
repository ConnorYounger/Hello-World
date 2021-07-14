using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BasicParentAI : MonoBehaviour
{

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

    private void Start()
    {
        StartCoroutine("ExecuteNarrativeElement");
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
}
