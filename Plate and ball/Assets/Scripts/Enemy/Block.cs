using System;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour, IEnemyObject
{
    public event Action ObjectDestroy;

    [SerializeField] private List<Sprite> spriteList;
    [SerializeField] private int score;


    private int life;
    private ParticleSystem blockParticle;
    private SpriteRenderer spriteRenderer;
    private UIScore uiScore;
    private GameObject canvasScore;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        life = spriteList.Count;
        blockParticle = GetComponent<ParticleSystem>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        this.gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[spriteList.Count - 1];
    }

    private void Start()
    {
        canvasScore = GameObject.FindGameObjectWithTag("UiScore");
        uiScore = canvasScore.GetComponent<UIScore>();
    }

    public void ApplyDamage()
    {
        life -= 1;
        if (life < 1)
        {
            blockParticle.Play();
            spriteRenderer.enabled = false;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            uiScore.ChangeScore(score);
            Score.SetScore(score);
            ObjectDestroy?.Invoke();
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = spriteList[life - 1];
        }
    }

    public AudioSource GetAudioSource()
    {
        return audioSource;
    }
}
