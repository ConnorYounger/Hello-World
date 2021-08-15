using UnityEngine;

public class StaminaSlider : MonoBehaviour
{
    private bool soundCheck = true;
    public bool gameStarted = false;

    public float gameTimer;
    private Animator anim;
    public GameObject baby;
    public GameObject loseText;
    public GameObject loseMenu;

    public float loseTimer = 0;

    public GameObject parentText;

    public RollOver check;
    

    private void Awake()
    {
        anim = baby.GetComponent<Animator>();
    }

    public void StartExercise()
    {
        gameStarted = true;
    }

    private void Update()
    {
        if (gameStarted == true)
        {
            gameTimer -= Time.deltaTime;

            //If we are at 0, start to refill
            if (gameTimer <= 0)
            {
                if (soundCheck == true)
                {
                    //playing lose sounds when game failed
                    check.soundEffectsManager.PlayLoseSound();
                    check.soundEffectsManager.PlayBabyCrySound();
                }

                //making sure audio only plays once
                soundCheck = false;

                //playing fail animation
                anim.SetBool("timeOut", true);

                //disabling instruction UI in game
                check.DisableText();

                //displaying lose UI and parent UI
                loseText.SetActive(true);
                check.parent.PlayLoseNarrative();

                //starting timer delay for lose menu
                loseTimer += Time.deltaTime;

                if (loseTimer >= 5)
                {
                    loseMenu.SetActive(true);
                }
            }
        }
    }
}
