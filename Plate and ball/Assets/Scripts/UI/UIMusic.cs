using UnityEngine;
using UnityEngine.UI;

public class UIMusic : MonoBehaviour
{
    private const string CONDITION_ON = "ON";
    private const string CONDITION_OFF = "OFF";

    private Text music;

    void Awake()
    {
        music = GetComponent<Button>().GetComponentInChildren<Text>();
        music.text = CONDITION_OFF;
    }
    public void ChangeMusic(bool status)
    {
        if (status)
        {
            music.text = CONDITION_OFF;
        }
        else
        {
            music.text = CONDITION_ON;
        }
    }

}
