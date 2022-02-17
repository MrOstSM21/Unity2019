using UnityEngine;

public class PauseMode
{
    public void PauseEnable()
    {
        Time.timeScale = 0f;
    }
    public void PauseDisable()
    {
        Time.timeScale = 1f;
    }
}
