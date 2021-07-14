using System.Collections;
using UnityEngine;

public class AnalogStickTweener : MonoBehaviour
{
    public float moveTime;
    public float scaleSize;

    public float xPos;
    public float yPos;

    public float xDestination;
    public float yDestination;

    public float x2Destination;
    public float y2Destination;

    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    public bool wobble = true;

    public void PlaySingleTween()
    {
        StartCoroutine("TweenStickSingle");
    }

    public void PlayAxisTween()
    {
        StartCoroutine("TweenStickAxis");
    }
    public void PlayWobbleTween()
    {
        StartCoroutine("TweenStickWobble");
    }

    private IEnumerator TweenStickSingle()
    {
        transform.LeanMoveLocal(new Vector2(xDestination, yDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    private IEnumerator TweenStickAxis()
    {
        transform.LeanMoveLocal(new Vector2(xDestination, yDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(x2Destination, y2Destination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    private IEnumerator TweenStickWobble()
    {
        while (wobble)
        {
            transform.LeanMoveLocal(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), moveTime).setEaseInOutQuint();
            transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

            yield return new WaitForSeconds(moveTime);

            transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
            transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
        }
    }
}
