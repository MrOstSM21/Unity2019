using UnityEngine;

public class Score
{
    private static int score = 0;
    private static int bestScore = 0;

    public static void SetScore(int scoreValue)
    {
        score += scoreValue;
    }
    public static void UploadBestScoreInStart()
    {
        bestScore = LoadBestScore();
    }
    public static int GetScore()
    {
        return score;
    }
    public static void SaveBestScore()
    {

        if (bestScore < score && score > bestScore)
        {
            bestScore = score;

            PlayerPrefs.DeleteKey("BestScore");
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
    public static int LoadBestScore()
    {
        if (PlayerPrefs.HasKey("BestScore"))
        {
            var scoreValue = PlayerPrefs.GetInt("BestScore");
            return scoreValue;
        }
        Debug.Log("Invalid key.");
        return 0;
    }
    public static void UpdateStartScore()
    {
        PlayerPrefs.DeleteKey("Score");
        score = 0;

    }
}
