using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    private int scoreValue;
    private Text score;

    private void Awake()
    {
        score = GetComponent<Text>();
        score.text = "0";
    }
    public void ChangeScore(int pointsForEnemy)
    {
        scoreValue += pointsForEnemy;
        score.text = scoreValue.ToString();
    }
    public void ScoreDefault()
    {
        scoreValue = 0;
        score.text = "0";
    }
}
