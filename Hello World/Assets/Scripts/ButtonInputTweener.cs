using UnityEngine;

public class ButtonInputTweener : MonoBehaviour
{
    public float axisMovement;
    public float scaleSize;
    public float scaleTime;
    public float moveTime;

     private void OnEnable()
    {
        PulseButton();
    }

    private void PulseButton()
    {
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
        transform.LeanMoveLocal(new Vector2(0, axisMovement), moveTime).setEaseInOutSine().setLoopPingPong();
    }
}
