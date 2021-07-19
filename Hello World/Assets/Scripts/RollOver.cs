using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollOver : MonoBehaviour
{
    private Animator anim;
    private MiniGameInputs controls;
    public ParentNarrative parent;
    public AnalogStickTweener animation;

    public GameObject liftButton;
    public GameObject swingButton;
    
    private int leftSwingAmount = 0;
    private int rightSwingAmount = 0;
    private int successCount = 0;

    private bool leftMovement = true;
    private bool rightMovement = false;
    public bool isLegUp = false;

    public float failTimer = 0;
    public float timeLimit = 0;
    public float coolDown = 0;

    private void Awake()
    {
        anim = GetComponent<Animator>();
        controls = new MiniGameInputs();
        SetInputActions();
    }


    private void OnEnable()
    {
        controls.RollOver.Enable();
    }

    private void OnDisable()
    {
        controls.RollOver.Disable();
    }

    void SetInputActions()
    {
        controls.RollOver.SwingLeft.performed += ctx => SwingLeft();
        controls.RollOver.SwingRight.performed += ctx => SwingRight();
        controls.RollOver.LegMovement.performed += ctx => LegUp();
        controls.RollOver.LegMovement.canceled += ctx => LegDown();
    }

    public void Update()
    {
        if (isLegUp == true)
        {
            failTimer += Time.deltaTime;
            coolDown += Time.deltaTime;
        }

        if (failTimer >= timeLimit)
        {
            anim.SetBool("legUp", false);
            anim.SetInteger("leftSwing", 0);
            anim.SetInteger("rightSwing", 0);
            failTimer = 0;
            coolDown = 0;
            isLegUp = false;
            parent.PlayFailNarrativeElement();
        }
    }

    void LegDown()
    {
        anim.SetBool("legUp", false);
        anim.SetInteger("leftSwing", 0);
        anim.SetInteger("rightSwing", 0);
        liftButton.SetActive(true);
        isLegUp = false;
        parent.PlayFailNarrativeElement();
        swingButton.SetActive(false);
    }

    void LegUp()
    {
        anim.SetBool("legUp", true);
        isLegUp = true;
        liftButton.SetActive(false);
        swingButton.SetActive(true);
        StartCoroutine(SwingAnimation());
    }

    private IEnumerator SwingAnimation()
    {
        while (isLegUp == true)
        {
            animation.StartCoroutine("TiltHorizontal");
            yield return new WaitForSeconds(4);
        }
    }

    void SwingLeft()
    {
        if (leftMovement == true && coolDown >= 1)
        {
            leftSwingAmount++;
            successCount++;
            anim.SetInteger("leftSwing", leftSwingAmount);
            leftMovement = false;
            rightMovement = true;
            failTimer = 0;
            coolDown = 0;
            parent.NarrativeElement(parent.sucessDialougeTexts[successCount - 1]);
        }
    }

    void SwingRight()
    {
        if (rightMovement == true && coolDown >= 1)
        {
            rightSwingAmount++;
            anim.SetInteger("rightSwing", rightSwingAmount);
            rightMovement = false;
            leftMovement = true;
            failTimer = 0;
            coolDown = 0;
        }
    }
}
