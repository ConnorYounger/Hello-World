using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerDelay : MonoBehaviour
{
    public string sceneToLoad;
    public int timeToWait;

    private void Start()
    {
        StartCoroutine("DelayForTime");
    }

    IEnumerator DelayForTime()
    {
        yield return new WaitForSeconds(timeToWait);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
