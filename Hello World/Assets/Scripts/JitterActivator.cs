using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro.Examples;
using UnityEngine.UI;

public class JitterActivator : MonoBehaviour
{
    public VertexJitter jitter;

    public void FixedUpdate()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            jitter.enabled = true;
        }
        if (EventSystem.current.currentSelectedGameObject != gameObject && jitter.enabled == true)
        {
            jitter.StopCoroutine("AnimateVertexColors");
            jitter.enabled = false;
        }
    }
}
