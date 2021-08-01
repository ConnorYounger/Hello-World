using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWithToy : MonoBehaviour
{
    public GameObject toyBall;
    public GameObject winText;
    public GameObject baby;
    public GameObject activate;

    public float pauseTimer = 0;

    public GameObject lBText;
    public GameObject rTText;
    public GameObject rBText;
    public GameObject lTText;

    public QWOP disableText;
    private Animator anim;

    public bool gameWon = false;

    void Start()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void Update()
    {
        if(gameWon == true)
        {
            pauseTimer += Time.deltaTime;
        }

        if (pauseTimer >= 5)
        {
            activate.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            winText.SetActive(true);
            anim.SetBool("gotBall", true);
            gameWon = true;
            lBText.SetActive(false);
            lTText.SetActive(false);
            rBText.SetActive(false);
            rTText.SetActive(false);
            disableText.parent.PlayWinNarrative();
            disableText.soundEffectManager.PlayWinSound();
        }
    }
}
