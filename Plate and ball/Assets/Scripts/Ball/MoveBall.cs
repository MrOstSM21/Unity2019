using UnityEngine;

public class MoveBall : MonoBehaviour, IMoveObject
{
    [SerializeField] private Transform parentObject;

    private const float FORCE = 300.0f;

    private Rigidbody2D rb;
    private bool isActive;
    private ObjectInputController inputStartMove;
    private AudioSource sound;

    void Start()
    {
        sound = GetComponent<AudioSource>();
        inputStartMove = FindObjectOfType<ObjectInputController>().GetComponent<ObjectInputController>();
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        transform.SetParent(parentObject);
    }

    void FixedUpdate()
    {
        if (inputStartMove.StartBallMovement() && !isActive)
        {
            Move();
        }
    }
    public void Move()
    {
        isActive = true;
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        AddForce();
    }

    public void AddForce(float direction = 0, float differenceOfPositions = 0)
    {
        StopMove();
        rb.AddForce(new Vector2(direction * Mathf.Abs(differenceOfPositions * FORCE), FORCE));
    }
    public void StopMove()
    {
        rb.velocity = Vector2.zero;
    }
}
