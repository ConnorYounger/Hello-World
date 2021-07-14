using System.Collections;
using UnityEngine;

public class AnalogStickTweener : MonoBehaviour
{
    public float xDestination;
    public float yDestination;
    public float x2Destination;
    public float y2Destination;
    public float xPos;
    public float yPos;
    public float moveTime;
    public float scaleSize;

    private void Start()
    {
        //StartCoroutine("TweenStickAxis");
    }

    public IEnumerator TweenStickSingle()
    {
        transform.LeanMoveLocal(new Vector2(xDestination, yDestination), moveTime).setEaseInOutQuint();
        transform.LeanScale(new Vector2(scaleSize, scaleSize), moveTime).setEaseInOutSine();
        
        yield return new WaitForSeconds(moveTime);
        
        transform.LeanMoveLocal(new Vector2(xPos, yPos), moveTime).setEaseInOutQuint();
        transform.LeanScale(Vector2.one, moveTime).setEaseInOutSine();
    }

    public IEnumerator TweenStickAxis()
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
}
