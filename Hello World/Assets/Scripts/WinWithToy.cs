using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWithToy : MonoBehaviour
{
    public GameObject toyBall;
    public GameObject winText;
    public GameObject baby;
    public float pauseTimer = 0;
    private Animator anim;

    public QWOP disableText;
    public PauseMenuController activate;

    public bool gameWon = false;

    void Start()
    {
        anim = baby.GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            toyBall.SetActive(false);
            winText.SetActive(true);
            anim.SetBool("gotBall", true);
            gameWon = true;
            Destroy(disableText.lBText);
            Destroy(disableText.rTText);
            Destroy(disableText.rBText);
            Destroy(disableText.lTText);

            pauseTimer += Time.deltaTime;

            if(pauseTimer >= 5)
            {
                activate.PauseGame();
            }
        }
    }
}
