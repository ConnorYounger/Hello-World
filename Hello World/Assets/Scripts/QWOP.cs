using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QWOP : MonoBehaviour
{
    public GameObject leftArm;
    public GameObject rightArm;
    public GameObject leftLeg;
    public GameObject rightLeg;
    public GameObject body;
    public GameObject head;

    public GameObject instructionText;
    public GameObject qText;
    public GameObject wText;
    public GameObject oText;
    public GameObject pText;

    public WinWithToy winWithToy;
    public CountDownBar countdown;

    //add bools for each limb to stop from moving backwards too much. 

    private char lastPressed;

    // Start is called before the first frame update
    void Start()
    {
        lastPressed = 'P';
    }

    // Update is called once per frame
    void Update()
    {
        if (winWithToy.gameWon == false && countdown.countdownBar.value > 0)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                qText.SetActive(false);
                if (lastPressed == 'P')
                {
                    leftArm.transform.position = Vector3.MoveTowards(leftArm.transform.position,
                    new Vector3(leftArm.transform.position.x, leftArm.transform.position.y, leftArm.transform.position.z + 0.5f), 1);
                    lastPressed = 'Q';
                }
                else
                {
                    leftArm.transform.position = Vector3.MoveTowards(leftArm.transform.position,
                    new Vector3(leftArm.transform.position.x, leftArm.transform.position.y, leftArm.transform.position.z - 0.5f), 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                wText.SetActive(false);
                if (lastPressed == 'O')
                {
                    rightArm.transform.position = Vector3.Lerp(rightArm.transform.position,
                    new Vector3(rightArm.transform.position.x, rightArm.transform.position.y, rightArm.transform.position.z + 0.5f), 1);
                    lastPressed = 'W';
                }
                else
                {
                    rightArm.transform.position = Vector3.Lerp(rightArm.transform.position,
                    new Vector3(rightArm.transform.position.x, rightArm.transform.position.y, rightArm.transform.position.z - 0.5f), 1);
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                oText.SetActive(false);
                if (lastPressed == 'Q')
                {
                    rightLeg.transform.position = Vector3.Lerp(rightLeg.transform.position,
                    new Vector3(rightLeg.transform.position.x, rightLeg.transform.position.y, rightLeg.transform.position.z + 0.5f), 1);
                    body.transform.position = Vector3.Lerp(body.transform.position,
                    new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z + 0.25f), 1);
                    head.transform.position = Vector3.Lerp(head.transform.position,
                    new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z + 0.25f), 1);
                    lastPressed = 'O';
                }
                else
                {
                    rightLeg.transform.position = Vector3.Lerp(rightLeg.transform.position,
                    new Vector3(rightLeg.transform.position.x, rightLeg.transform.position.y, rightLeg.transform.position.z - 0.5f), 1);
                    body.transform.position = Vector3.Lerp(body.transform.position,
                    new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z - 0.25f), 1);
                    head.transform.position = Vector3.Lerp(head.transform.position,
                    new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - 0.25f), 1);
                    lastPressed = 'O';
                }
            }

            if (Input.GetKeyDown(KeyCode.P))
            {
                pText.SetActive(false);
                instructionText.SetActive(false);
                if (lastPressed == 'W')
                {
                    leftLeg.transform.position = Vector3.Lerp(leftLeg.transform.position, 
                    new Vector3(leftLeg.transform.position.x, leftLeg.transform.position.y, leftLeg.transform.position.z + 0.5f), 1);
                    body.transform.position = Vector3.Lerp(body.transform.position,
                    new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z + 0.25f), 1);
                    head.transform.position = Vector3.Lerp(head.transform.position,
                    new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z + 0.25f), 1);
                    lastPressed = 'P';
                }
                else
                {
                    leftLeg.transform.position = Vector3.Lerp(leftLeg.transform.position,
                    new Vector3(leftLeg.transform.position.x, leftLeg.transform.position.y, leftLeg.transform.position.z - 0.5f), 1);
                    body.transform.position = Vector3.Lerp(body.transform.position,
                    new Vector3(body.transform.position.x, body.transform.position.y, body.transform.position.z - 0.25f), 1);
                    head.transform.position = Vector3.Lerp(head.transform.position,
                    new Vector3(head.transform.position.x, head.transform.position.y, head.transform.position.z - 0.25f), 1);
                }
            }
        }
    }
}
