using UnityEngine;

public class BallCollision : MonoBehaviour
{
    [SerializeField] private MoveBall ball;

    private float lastPositionBall;
    private SoundPlayer soundPlayer;

    private void Start()
    {
        soundPlayer = FindObjectOfType<SoundPlayer>();
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        HorizontalOffsetBall(collision);

        EndGame(collision);

        DestroyObject(collision);

        PlaySound(collision);
    }
    private void HorizontalOffsetBall(Collision2D collision) //Removes endless vertical movement.
    {
        float newPositionBall = transform.position.x;

        if (collision.gameObject.TryGetComponent(out MovePlate plate))
        {
            if (newPositionBall > lastPositionBall - 0.1 && lastPositionBall + 0.1 > newPositionBall)
            {
                float playerCenterPosition = plate.transform.position.x;
                float differenceOfPositions = playerCenterPosition - newPositionBall;
                float direction = newPositionBall < playerCenterPosition ? -1 : 1;
                ball.AddForce(direction, differenceOfPositions);
            }

            lastPositionBall = newPositionBall;
        }
    }
    private void EndGame(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out SceneLoader sceneLoader))
        {
            Destroy(this.gameObject);
            Score.SaveBestScore();
            sceneLoader.EndGame();
        }
    }
    private void DestroyObject(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IEnemyObject enemy))
        {
            enemy.ApplyDamage();
            soundPlayer.PlayImpactSound(enemy.GetAudioSource());
        }
    }
    private void PlaySound(Collision2D collision)
    {
      
        if (!collision.gameObject.TryGetComponent(out IEnemyObject enemy) && !collision.gameObject.TryGetComponent(out SceneLoader sceneLoader))
        {
            soundPlayer.PlayImpactSound(ball.GetComponent<AudioSource>());
        }
       
        
       
    }
}
