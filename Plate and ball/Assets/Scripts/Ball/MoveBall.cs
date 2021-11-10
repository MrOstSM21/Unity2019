using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBall : MonoBehaviour, IMoveObject
{
    [SerializeField] private Transform parentObject;

    private const float force = 300.0f;

    private float lastPositionBall;
    private Rigidbody2D rb;
    private bool isActive;
    private ObjectInputController inputStartMove;

    void Start()
    {
        inputStartMove = new ObjectInputController();
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
        lastPositionBall = transform.position.x;
        isActive = true;
        transform.SetParent(null);
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.AddForce(Vector2.up * force);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        float newPositionBall = transform.position.x;

        if (collision.gameObject.TryGetComponent(out MovePlate ball))
        {
            if (newPositionBall > lastPositionBall - 0.1 && lastPositionBall + 0.1 > newPositionBall)
            {
                rb.velocity = Vector2.zero;
                float playerCenterPosition = parentObject.GetComponent<Transform>().position.x;
                float differenceOfPositions = playerCenterPosition - newPositionBall;
                float direction = newPositionBall < playerCenterPosition ? -1 : 1;
                rb.AddForce(new Vector2(direction * Mathf.Abs(differenceOfPositions * force), force));
            }
        }

        lastPositionBall = newPositionBall;
    }
}
