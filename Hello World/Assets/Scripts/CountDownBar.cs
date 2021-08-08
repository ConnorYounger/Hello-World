using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public bool gameStarted = false;
    public bool soundCheck = true;
    public float loseDelay = 0;

    public GameObject baby;
    public GameObject loseMenu;

    public WinWithToy check;
    public QWOP call;
    public ParentNarrative parent;
    public ExerciseSoundEffectsManager soundEffectManager;

    public Slider countdownBar;
    private Animator anim;

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
        countdownBar.value = countdownBar.maxValue;
    }

    public void StartExercise()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (gameStarted == true)
        {
            countdownBar.value -= Time.deltaTime;

            if (countdownBar.value <= 0 && check.gameWon == false)
            {
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
                call.DisableText();

                loseDelay += Time.deltaTime;

                if (loseDelay >= 5)
                {
                    loseMenu.SetActive(true);
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
