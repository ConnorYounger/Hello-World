using UnityEngine;

public class ButtonInputTweener : MonoBehaviour
{
    public float axisMovement;
    public float scaleSize;
    public float scaleTime;
    public float moveTime;

    private void Start()
    {
        PulseButton();
    }

    private void PulseButton()
    {
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
        transform.LeanMoveLocalY(axisMovement, moveTime).setEaseInOutSine().setLoopPingPong();
    }
}