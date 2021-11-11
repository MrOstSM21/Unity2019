using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScore : MonoBehaviour
{
    
    private int scoreValue;
    private Text score;
    private void Awake()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
        score.text = scoreValue.ToString();
    }
    public void ChangeScore(int pointsForEnemy)
    {
        scoreValue += pointsForEnemy;
        score.text = scoreValue.ToString();
    }
}
