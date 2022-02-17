using UnityEngine;
using UnityEngine.UI;

public class UIFinishBestScore : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "BEST SCORE: " + Score.LoadBestScore().ToString();
    }
}
