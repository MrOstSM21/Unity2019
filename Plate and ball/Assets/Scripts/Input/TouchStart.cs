using UnityEngine;

public class TouchStart : MonoBehaviour
{
    [SerializeField] private ObjectInputController startObject;

    private void OnMouseDown()
    {
        startObject.StartBallMovement();
    }
}
