using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public bool gameStarted = false;
    public float countDownTime = 60;
    public float pauseTimer = 0;

    public GameObject loseText;
    public GameObject baby;
    public GameObject pauseMenu;
    public GameObject activate;
    
    public WinWithToy winWithToy;
    public QWOP disableText;
    
    public Slider countdownBar;
    private Animator anim;

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void Start()
    {
        //Set the max value to the refill time
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
            if (winWithToy.gameWon == false)
            {
                if (countDown) //Scale the countdown time to go faster than the refill time
                    countdownBar.value -= Time.deltaTime;

                //If we are at 0, start to refill
                if (countdownBar.value <= 0)
                {
                    if (countDown == true)
                    {
                        disableText.soundEffectManager.PlayLoseSound();
                        disableText.soundEffectManager.PlayBabyCrySound();
                    }

                    countDown = false;
                    allowInputs = false;
                    anim.SetBool("timeOut", true);
                    loseText.SetActive(true);
                    Destroy(disableText.lBText);
                    Destroy(disableText.rTText);
                    Destroy(disableText.rBText);
                    Destroy(disableText.lTText);
                    disableText.parent.PlayLoseNarrative();
                    pauseTimer += Time.deltaTime;

                    if (pauseTimer >= 5)
                    {
                        activate.SetActive(true);
                    }
                }
                else
                {
                    countDown = true;
                    allowInputs = true;
                }
            }
        }
    }
}
