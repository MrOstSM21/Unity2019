using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private UIMusic uIMusic;
    private bool condition = true;

    private void Start()
    {
        uIMusic = FindObjectOfType<UIMusic>();
    }
    public void PlayImpactSound(AudioSource audioSource)
    {
        audioSource.Play();
    }
    public void ChangeMusicCondition()
    {
        if (condition)
        {
            uIMusic.GetComponent<AudioSource>().Stop();
            condition = false;
            uIMusic.ChangeMusic(condition);
        }
        else
        {
            uIMusic.GetComponent<AudioSource>().Play();
            condition = true;
            uIMusic.ChangeMusic(condition);
        }
        
    }
}
