using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro.Examples;

public class JitterActivator : MonoBehaviour
{
    public VertexJitter jitter;
 
    public void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            jitter.enabled = true;
        }
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            jitter.enabled = false;
        }
    }
}
