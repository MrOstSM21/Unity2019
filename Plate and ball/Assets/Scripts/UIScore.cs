using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{

    private int scoreValue;
    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
        score.text = "SCORE: 0";
    }
    public void ChangeScore(int pointsForEnemy)
    {
        scoreValue += pointsForEnemy;
        score.text = "SCORE: " + scoreValue.ToString();
    }

}
