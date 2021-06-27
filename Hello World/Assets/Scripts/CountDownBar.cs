using UnityEngine;
using UnityEngine.UI;

public class CountDownBar : MonoBehaviour
{
    public static bool allowInputs;

    public Slider countdownBar;
    private bool countDown = true;

    public float countDownTime = 60;
    public GameObject loseText;

    public WinWithToy winWithToy;

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
                loseText.SetActive(true);
            }
            else
            {
                countDown = true;
                allowInputs = true;
            }
        }
    }
}
