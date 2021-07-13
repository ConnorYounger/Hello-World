using UnityEngine;

public class AnalogStickTweener : MonoBehaviour
{
    public float xPos;
    public float yPos;
    public float tiltDistance;
    public float moveTime;
    public float scaleSize;

    private void Start()
    {
        TweenRight();
    }

    public void TweenLeft()
    {
        transform.LeanMoveLocalX(-tiltDistance, moveTime).setEaseInOutQuint().setLoopPingPong();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
    }

    public void TweenRight()
    {
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint().setLoopPingPong();
        //transform.LeanMoveLocalX(tiltDistance, moveTime).setEaseInOutQuint().setLoopPingPong();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
    }
}
