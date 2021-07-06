using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinWithToy : MonoBehaviour
{
    public GameObject toyBall;
    public GameObject winText;
    public GameObject baby;
    private Animator anim;

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
        }
    }

    public void SwitchScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
