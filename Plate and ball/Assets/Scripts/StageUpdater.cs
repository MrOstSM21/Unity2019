using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageUpdater : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    private UIScore score;
    private MoveBall ball;
    private MovePlate plate;

    public void LevelUpdate()
    {
        ScoreClearing();
        Destroy();
        CreatePlate();
    }
    private void ScoreClearing()
    {
        var canvasScore = GameObject.FindGameObjectWithTag("UiScore");
        score = canvasScore.GetComponent<UIScore>();
        score.ScoreDefault();
    }
    private void CreatePlate()
    {
        Instantiate(prefab);
    }
    private void Destroy()
    {
        ball = FindObjectOfType<MoveBall>();
        plate = FindObjectOfType<MovePlate>();
        Destroy(ball.gameObject);
        Destroy(plate.gameObject);
    }

}
