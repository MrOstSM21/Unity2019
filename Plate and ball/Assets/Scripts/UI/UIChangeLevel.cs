using UnityEngine;

public class UIChangeLevel : MonoBehaviour
{
    private GameObject changeLevel;

    private void Awake()
    {
        changeLevel = this.gameObject;
        changeLevel.SetActive(true);
    }

    public void ChangeCondition()
    {
        var condition = changeLevel.activeSelf;
        if (condition)
        {
            changeLevel.SetActive(false);
        }
        else
        {
            changeLevel.SetActive(true);
        }
    }

}
