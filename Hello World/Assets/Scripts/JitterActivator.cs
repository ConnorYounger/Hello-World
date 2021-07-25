using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro.Examples;
using UnityEngine.UI;

public class JitterActivator : MonoBehaviour
{
    public VertexJitter jitter;
    public bool canJitter;

    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            canJitter = true;
            //jitter.enabled = true;
        } else { canJitter = false; }
        /*
        if (EventSystem.current.currentSelectedGameObject != gameObject && jitter.enabled == true)
        {
            jitter.StopCoroutine("AnimateVertexColors");
            jitter.enabled = false;
        }*/

        ToggleJitter();
    }

    public void ToggleJitter()
    {
        if (canJitter)
        {
            jitter.enabled = true;
        } else 
        { 
            jitter.StopCoroutine("AnimateVertexColors");
            jitter.enabled = false;
        }
    }
}
