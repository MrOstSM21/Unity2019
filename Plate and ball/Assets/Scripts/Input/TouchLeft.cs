using UnityEngine;

public class TouchLeft : MonoBehaviour, ITouch
{
    [SerializeField] private ObjectInputController startObject;

    public void OnMouseDown()
    {
        startObject.SetHorizontal(-1f);
    }

    public void OnMouseUp()
    {
        startObject.SetHorizontal(0f);
    }
}
