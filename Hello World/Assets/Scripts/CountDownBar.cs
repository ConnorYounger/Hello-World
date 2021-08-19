using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class CountDownBar : MonoBehaviour
{
    public bool gameStarted = false;
    public bool soundCheck = true;
    public float loseDelay = 0;

    public GameObject baby;
    public GameObject loseMenu;

    public WinWithToy wwt;
    public QWOP qwop;
    public ParentNarrative parent;
    public ExerciseSoundEffectsManager soundEffectManager;
    public ExerciseStart startManager;

    public float gameTimer = 0;
    private Animator anim;

    private void Awake()
    {
        //setting up animations to play
        anim = baby.GetComponent<Animator>();
    }

    private void Update()
    {
        if (qwop.gameManager == true)
        {
            //starting timer 
            gameTimer -= Time.deltaTime;

            if (gameTimer <= 0 && wwt.gameWon == false)
            {
                startManager.PlayLoseCutscene();

                if (soundCheck == true)
                {
                    //calling from QWOP to play sounds
                    soundEffectManager.PlayLoseSound();
                    StartCoroutine("DelaySound");
                }

                //making sure audio only plays once
                soundCheck = false;
             
                //enabling UI lose text
                parent.PlayLoseNarrative();

                //setting bool to activate lose animation
                anim.SetBool("timeOut", true);

                //calling function from QWOP to disable text
                qwop.DisableText();

                loseDelay += Time.deltaTime;

                if (loseDelay >= 5)
                {
                    loseMenu.SetActive(true);
                    EventSystem.current.SetSelectedGameObject(GameObject.Find("LoseButton"));
                }
            }
        }
    }

    public IEnumerator DelaySound()
    {
        yield return new WaitForSeconds(3);
        soundEffectManager.PlayBabyCrySound();
    }
}
