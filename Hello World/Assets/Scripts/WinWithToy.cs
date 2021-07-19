using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinWithToy : MonoBehaviour
{
    public GameObject toyBall;
    public GameObject winText;
    public GameObject baby;
    private Animator anim;

    public QWOP disableText;

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
        }
    }
}
