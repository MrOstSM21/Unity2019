using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyBall : MonoBehaviour
{
   


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out MoveBall ball))
        {
            Destroy(ball.gameObject);
            SceneManager.LoadScene(2);
        }

    }
}
