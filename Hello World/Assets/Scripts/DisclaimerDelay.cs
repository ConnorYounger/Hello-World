using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DisclaimerDelay : MonoBehaviour
{
    public string sceneToLoad;

    private void Start()
    {
        StartCoroutine("DelayForTime");
    }

    IEnumerator DelayForTime()
    {
        yield return new WaitForSeconds(5);
        LoadNextScene();
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
