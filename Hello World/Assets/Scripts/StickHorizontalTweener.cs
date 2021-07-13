using UnityEngine;

public class StickHorizontalTweener : MonoBehaviour
{
    public float tiltDistance;
    public float moveTime;
    public float scaleSize;

    private void Start()
    {
        TweenRight();
    }

    private void OnEnable()
    {
    }

    public void TweenLeft()
    {
        transform.LeanMoveLocalX(-tiltDistance, moveTime).setEaseInOutQuint().setLoopPingPong();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
    }

    public void TweenRight()
    {
        transform.LeanMoveLocalX(tiltDistance, moveTime).setEaseInOutQuint().setLoopPingPong();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine().setLoopPingPong();
    }
}
