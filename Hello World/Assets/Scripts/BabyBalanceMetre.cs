using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyBalanceMetre : MonoBehaviour
{
    public GameObject metreArrow;
    public float dimentions = 180;

    public BabyBalancing babyBalancing;

    void Update()
    {
        UpdateArrowPosition();
    }

    void UpdateArrowPosition()
    {
        GameObject spine = babyBalancing.spine;
        float pos = (-spine.transform.localRotation.y) / babyBalancing.CalculateMaxBalanceValue();
        pos = Mathf.Clamp(pos, -0.7f, 0.7f);

        metreArrow.transform.position = new Vector3(transform.position.x + (pos * 250), metreArrow.transform.position.y, metreArrow.transform.position.z);
    }
}
