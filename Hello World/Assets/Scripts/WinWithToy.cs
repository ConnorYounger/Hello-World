using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWithToy : MonoBehaviour
{
    public GameObject toyBall;
    public GameObject winText;
    public GameObject baby;
    public GameObject winMenu;

    public float winDelay = 0;

    public QWOP qwop;
    public ExerciseStart startManager;
    private Animator anim;

    public bool gameWon = false;

    void Start()
    {
        //setting up animations
        anim = baby.GetComponent<Animator>();
    }

    private void Update()
    {
        if(gameWon == true)
        {
            winDelay += Time.deltaTime;
        }

        if (winDelay >= 5)
        {
            winMenu.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            qwop.gameManager = false;

            startManager.PlayWinCutscene();

            gameWon = true;
            winText.SetActive(true);

            //setting bool to play animation
            anim.SetBool("gotBall", true);

            //calling functions and variables from QWOP script to disable text, show UI text, and play sounds 
            qwop.DisableText();
            qwop.parent.PlayWinNarrative();
            qwop.soundEffectManager.PlayWinSound();
        }
    }
}
