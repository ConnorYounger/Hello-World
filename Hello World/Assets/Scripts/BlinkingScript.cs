using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BlinkingScript : MonoBehaviour
{
    public RectTransform upperBox;
    public RectTransform lowerBox;
    public GameObject pressText;
    private MiniGameInputs controls;

    public float speed = 0.70f;
    public int blinkTimes = 3;
    public bool endClosing = false;
    public bool isBlinking = false;


    private Vector3 originalUpperPosition;
    private Vector3 originalLowerPosition;
    private Vector3 endUpper;
    private Vector3 endLower;

    public int currentBlink = 1;

    public enum Action
    {
        Open,
        Close
    };

    void Awake()
    {
        originalUpperPosition = upperBox.position;
        originalLowerPosition = lowerBox.position;
        controls = new MiniGameInputs();
        SetInputActions();
    }

    void SetInputActions()
    {
        controls.Blinking.Key1.performed += ctx => StartCoroutine(Blinking());
    }
    private void OnEnable()
    {
        controls.Blinking.Enable();
    }

    private void OnDisable()
    {
        controls.Blinking.Disable();
    }

    private IEnumerator Blinking()
    {
        if (currentBlink <= blinkTimes && isBlinking == false)
        {
            isBlinking = true;
            pressText.SetActive(false);

            endUpper = originalUpperPosition;
            endLower = originalLowerPosition;

            endUpper.y += (50 * currentBlink);
            endLower.y -= (50 * currentBlink);

            // open eyelids
            yield return moveEyelids(endUpper, endLower, Action.Open);

            //check if we want to end the blink closing the eyes
            if (currentBlink == blinkTimes && !endClosing)
            {
                originalUpperPosition.y = Screen.height * 2;
                originalLowerPosition.y = -Screen.height;
            }

            // close eyelids
            yield return moveEyelids(originalUpperPosition, originalLowerPosition, Action.Close);

            currentBlink++;
            pressText.SetActive(true);
            isBlinking = false;

            if (currentBlink > blinkTimes)
            {
                pressText.SetActive(false);
            }
        }
    }

    private IEnumerator moveEyelids(Vector3 upperLid, Vector3 lowerLid, Action action)
    {
        float elapsedTime = 0;

        while (elapsedTime < speed)
        {
            float duration = (elapsedTime / speed);

            if (action == Action.Open)
            {
                upperBox.position = Vector3.Lerp(originalUpperPosition, upperLid, duration);
                lowerBox.position = Vector3.Lerp(originalLowerPosition, lowerLid, duration);
            }
            else
            {
                upperBox.position = Vector3.Lerp(endUpper, upperLid, duration);
                lowerBox.position = Vector3.Lerp(endLower, lowerLid, duration);
            }

            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
