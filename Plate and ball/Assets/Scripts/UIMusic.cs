using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMusic : MonoBehaviour
{
    private readonly string conditionOn = "Music: ON";
    private readonly string conditionOff = "Music: OFF";

    private Text music;
    
   

    void Awake()
    {

        music = GetComponent<Button>().GetComponentInChildren<Text>();
        music.text = conditionOff;
        
    }
   public void ChangeMusic(bool status)
    {
        if (status)
        {
            music.text = conditionOff;
        }
        else
        {
            music.text = conditionOn;
        }
    }
   
}
