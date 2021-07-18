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

    [Header("Wobble Bounds")]
    public float xMax;
    public float yMax;
    public float xMin;
    public float yMin;

    private bool wobble = true;
    #endregion

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
    private IEnumerator TiltHorizontal()
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
            transform.LeanMoveLocal(new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)), moveTime).setEaseInOutQuint();
            transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();

            yield return new WaitForSeconds(moveTime);

            transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
            transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
        }
    }
    #endregion
}