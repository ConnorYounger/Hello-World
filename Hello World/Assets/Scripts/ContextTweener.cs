using System.Collections;
using UnityEngine;

public class ContextTweener : MonoBehaviour
{
    public float tweenTime;
    public float startTime;
    public float displayTime;

    public void Start()
    {
        transform.localScale = Vector2.zero;
        StartCoroutine("Tweener");
    }

    private IEnumerator Tweener()
    {
        yield return new WaitForSeconds(startTime);
        transform.LeanScale(Vector2.one, tweenTime);
        yield return new WaitForSeconds(displayTime);
        transform.LeanScale(Vector2.zero, tweenTime);
    }
}