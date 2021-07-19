using System.Collections;
using UnityEngine;

public class AnalogStickTweener : MonoBehaviour
{
    #region Variables
    [Header("Global")]
    public float moveTime;
    public float scaleSize;
    public float xPos;
    public float yPos;

    [Header("Tilt Destinations")]
    public float leftTiltDestination;
    public float rightTiltDestination;
    public float upTiltDestination;
    public float downtiltDestination;

    private bool wobble = true;
    #endregion

    public void TestTween()
    {
        StartCoroutine(TiltUp());
    }

    #region Single tilt tweens
    public IEnumerator TiltLeft()
    {
        transform.LeanMoveLocal(new Vector2(leftTiltDestination, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    public IEnumerator TiltRight()
    {
        transform.LeanMoveLocal(new Vector2(rightTiltDestination, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    public IEnumerator TiltUp()
    {
        transform.LeanMoveLocal(new Vector2(xPos, upTiltDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    public IEnumerator TiltDown()
    {
        transform.LeanMoveLocal(new Vector2(xPos, downtiltDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }
    #endregion

    #region Axis and wobble tweens
    public IEnumerator TiltHorizontal()
    {
        transform.LeanMoveLocal(new Vector2(leftTiltDestination, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(rightTiltDestination, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    private IEnumerator TiltVertical()
    {
        transform.LeanMoveLocal(new Vector2(xPos, upTiltDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, downtiltDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

        yield return new WaitForSeconds(moveTime);

        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    private IEnumerator TiltWobbler()
    {
        while (wobble)
        {
            transform.LeanMoveLocal(new Vector2(Random.Range(leftTiltDestination, rightTiltDestination), Random.Range(downtiltDestination, upTiltDestination)), moveTime).setEaseInOutQuint();
            transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

            yield return new WaitForSeconds(moveTime);

            transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
            transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
        }
    }
    #endregion
}