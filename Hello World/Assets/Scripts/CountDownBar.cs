using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public static bool allowInputs;
    private bool countDown = true;
    public float countDownTime = 60;

    public GameObject loseText;
    public GameObject baby;
    public GameObject pauseMenu;
    public float pauseTimer = 0;

    public WinWithToy winWithToy;
    public QWOP disableText;
    public PauseMenuController activate;

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

    private void Update()
    {
        if (winWithToy.gameWon == false)
        {
            if (countDown) //Scale the countdown time to go faster than the refill time
                countdownBar.value -= Time.deltaTime;

            //If we are at 0, start to refill
            if (countdownBar.value <= 0)
            {
                countDown = false;
                allowInputs = false;
                anim.SetBool("timeOut", true);
                loseText.SetActive(true);
                Destroy(disableText.lBText);
                Destroy(disableText.rTText);
                Destroy(disableText.rBText);
                Destroy(disableText.lTText);

                pauseTimer += Time.deltaTime;

                if (pauseTimer >= 5)
                {
                    activate.PauseGame();
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
