using UnityEngine;
using UnityEngine.UI;

public class UIFinishScore : MonoBehaviour
{
    private Text text;

    private void Awake()
    {
        text = GetComponent<Text>();
        text.text = "YOUR SCORE: " + Score.GetScore().ToString();
    }
}
