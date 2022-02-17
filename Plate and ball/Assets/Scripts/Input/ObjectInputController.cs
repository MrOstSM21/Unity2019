using UnityEngine;

public class ObjectInputController : MonoBehaviour
{
    private bool startBallMovement;
    private float horizontalOffset;

    public void SetHorizontal(float value)
    {
        horizontalOffset = value;
    }

    public float HorizontalInput()
    {
        return horizontalOffset;
    }

    public bool StartBallMovement()
    {
        return startBallMovement;
    }

    private void OnMouseDown()
    {
        startBallMovement = true;
    }

    private void OnMouseUp()
    {
        startBallMovement = false;
    }

}

