using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LevelScene()
    {
        Score.UploadBestScoreInStart(); //TODO: Move to another class.
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void EndGame()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }
    public void FinishGame()
    {
        SceneManager.LoadScene(2);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
