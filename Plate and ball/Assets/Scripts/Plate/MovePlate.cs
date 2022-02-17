using UnityEngine;

public class MovePlate : MonoBehaviour, IMoveObject
{
    [SerializeField] private float moveSpeed = 5.0f;

    private float moveLimit = 1.69f;
    private ObjectInputController inputMove;

    void Update()
    {
        Move();
    }
    public void Move()
    {
        inputMove =FindObjectOfType<ObjectInputController>().GetComponent<ObjectInputController>();
        transform.localPosition = new Vector2(Mathf.Clamp(transform.position.x, -moveLimit, moveLimit), transform.position.y);
        transform.Translate(Vector2.right * inputMove.HorizontalInput() * moveSpeed * Time.deltaTime);
    }

}
